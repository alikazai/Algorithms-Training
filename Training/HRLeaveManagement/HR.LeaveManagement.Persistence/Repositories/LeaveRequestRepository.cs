using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{

    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest =
            await EntityDbContext.Set<LeaveRequest>().Include(q => q.LeaveType).FirstOrDefaultAsync(i => i.Id == id);
        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
    {
        var leaveRequest =
            await EntityDbContext.Set<LeaveRequest>().Include(q => q.LeaveType).ToListAsync();
        return leaveRequest;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
    {
        leaveRequest.Approved = approvalStatus;
        EntityDbContext.Entry(leaveRequest).State = EntityState.Modified;
        await EntityDbContext.SaveChangesAsync();
    }
}