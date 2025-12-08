using Workforce.Domain.Core.TourScheduleManagement.TourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.TourSchedule
{
    public interface ITourScheduleService : ICrudService<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule>
    {
        Task<IList<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);
    }
}
