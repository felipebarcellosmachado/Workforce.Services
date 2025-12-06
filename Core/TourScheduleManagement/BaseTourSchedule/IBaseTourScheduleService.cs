using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public interface IBaseTourScheduleService : ICrudService<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>
    {
        Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);
    }
}
