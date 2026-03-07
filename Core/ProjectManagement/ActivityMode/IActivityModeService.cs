using Workforce.Domain.Core.ProjectManagement.Activity.Entity;

namespace Workforce.Services.Core.ProjectManagement.ActivityMode
{
    public interface IActivityModeService
    {
        Task<Domain.Core.ProjectManagement.Activity.Entity.ActivityMode> InsertAsync(Domain.Core.ProjectManagement.Activity.Entity.ActivityMode mode, CancellationToken ct = default);
        Task<Domain.Core.ProjectManagement.Activity.Entity.ActivityMode> UpdateAsync(Domain.Core.ProjectManagement.Activity.Entity.ActivityMode mode, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
