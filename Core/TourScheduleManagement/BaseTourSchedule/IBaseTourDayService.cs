using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public interface IBaseTourDayService : ICrudService<BaseTourScheduleDay>
    {
        Task<IList<BaseTourScheduleDay>> GetAllByBaseTourScheduleIdAsync(int baseTourScheduleId, CancellationToken ct = default);
    }
}
