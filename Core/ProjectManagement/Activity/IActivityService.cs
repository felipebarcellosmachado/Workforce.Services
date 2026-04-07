using Workforce.Domain.Core.ProjectManagement.Activity.Entity;

namespace Workforce.Services.Core.ProjectManagement.Activity
{
    public interface IActivityService : ICrudService<Domain.Core.ProjectManagement.Activity.Entity.Activity>
    {
        Task<IList<Domain.Core.ProjectManagement.Activity.Entity.Activity>> GetAllByProjectIdAsync(int projectId, CancellationToken ct = default);
        Task UpdatePredecessorsAsync(int activityId, IList<int> predecessorIds, CancellationToken ct = default);
        Task UpdateDatesAsync(int activityId, DateTime? startDate, DateTime? endDate, CancellationToken ct = default);
    }
}
