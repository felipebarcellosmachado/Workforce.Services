using Workforce.Services;
using Workforce.Domain.Core.LeaveManagement.LeaveTake.Entity;

namespace Workforce.Services.Core.LeaveManagement.LeaveTake
{
    public interface ILeaveTakeService : ICrudService<Domain.Core.LeaveManagement.LeaveTake.Entity.LeaveTake>
    {
        Task<IList<Domain.Core.LeaveManagement.LeaveTake.Entity.LeaveTake>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    }
}