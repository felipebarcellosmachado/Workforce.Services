using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public interface IBaseTourScheduleDemandService : ICrudService<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>
    {
        Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>> GetAllByBaseTourScheduleIdAsync(int baseTourScheduleId, CancellationToken ct = default);
        Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>> GetAllByBaseTourSchedulePeriodIdAsync(int baseTourSchedulePeriodId, CancellationToken ct = default);
    }
}
