using Workforce.Services;
using Workforce.Domain.Core.LeaveManagement.LeaveRequest.Entity;
using Workforce.Domain.Core.LeaveManagement.LeaveRequest.Enum;

namespace Workforce.Services.Core.LeaveManagement.LeaveRequest
{
    public interface ILeaveRequestService : ICrudService<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>
    {
        Task<IList<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest> ApproveAsync(int id, CancellationToken ct = default);
        Task<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest> RejectAsync(int id, CancellationToken ct = default);
        Task<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest> CancelAsync(int id, CancellationToken ct = default);
    }
}