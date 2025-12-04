using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public interface IBaseTourScheduleService : ICrudService<BaseTourScheduleEstimative>
    {
        Task<IList<BaseTourScheduleEstimative>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<BaseTourScheduleEstimative?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);
    }
}
