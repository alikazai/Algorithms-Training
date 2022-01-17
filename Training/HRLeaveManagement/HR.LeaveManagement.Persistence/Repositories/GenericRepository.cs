using HR.LeaveManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected DbContext EntityDbContext;

    public GenericRepository(DbContext dbContext)
    {
        EntityDbContext = dbContext;
    }

    public async Task<T?> Get(int id)
    {
        return await EntityDbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await EntityDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        await EntityDbContext.AddAsync(entity);
        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        return entity != null;
    }

    public async Task Update(T entity)
    {
        EntityDbContext.Entry(entity).State = EntityState.Modified; 
    }

    public async Task Delete(T entity)
    {
        EntityDbContext.Set<T>().Remove(entity);
    }
}