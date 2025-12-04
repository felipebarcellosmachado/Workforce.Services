using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public interface IBaseTourScheduleTourScheduleService : ICrudService<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>
    {
        Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>> GetAllByBaseTourScheduleEstimativeIdAsync(int baseTourScheduleEstimativeId, CancellationToken ct = default);
        Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>> GetAllByBaseTourSchedulePeriodIdAsync(int baseTourSchedulePeriodId, CancellationToken ct = default);
    }
}
