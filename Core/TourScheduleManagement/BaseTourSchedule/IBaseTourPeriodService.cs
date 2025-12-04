using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public interface IBaseTourPeriodService : ICrudService<BaseTourSchedulePeriod>
    {
        Task<IList<BaseTourSchedulePeriod>> GetAllByBaseTourDayIdAsync(int baseTourDayId, CancellationToken ct = default);
    }
}
