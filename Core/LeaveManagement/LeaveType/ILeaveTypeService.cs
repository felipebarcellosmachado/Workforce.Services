using Workforce.Services;

namespace Workforce.Services.Core.LeaveManagement.LeaveType
{
    public interface ILeaveTypeService : ICrudService<Domain.Core.LeaveManagement.LeaveType.Entity.LeaveType>
    {
        Task<IList<Domain.Core.LeaveManagement.LeaveType.Entity.LeaveType>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    }
}