using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{

    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await EntityDbContext.Set<LeaveAllocation>().Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);
        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocation = await EntityDbContext.Set<LeaveAllocation>().Include(q => q.LeaveType).ToListAsync();
        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        var leaveAllocation = await EntityDbContext.Set<LeaveAllocation>().Where(q => q.EmployeeId == userId)
            .Include(q => q.LeaveType).ToListAsync();
        return leaveAllocation;
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await EntityDbContext.Set<LeaveAllocation>().AnyAsync(q =>
            q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await EntityDbContext.Set<LeaveAllocation>().AddRangeAsync(allocations);
        await EntityDbContext.SaveChangesAsync();
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        return await EntityDbContext.Set<LeaveAllocation>()
            .FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId);
    }
}