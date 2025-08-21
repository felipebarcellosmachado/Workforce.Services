using Workforce.Services;
using Workforce.Domain.Core.LeaveManagement.LeaveRequest.Entity;

namespace Workforce.Services.Core.LeaveManagement.LeaveRequest
{
    public interface ILeaveRequestService : ICrudService<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>
    {
        Task<IList<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    }
}