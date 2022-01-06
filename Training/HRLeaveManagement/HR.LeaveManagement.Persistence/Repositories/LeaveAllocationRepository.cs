using HR.LeaveManagement.Application.Persistence.Contracts;
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

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        var leaveAllocation = await EntityDbContext.Set<LeaveAllocation>().Include(q => q.LeaveType).ToListAsync();
        return leaveAllocation;
    }
}