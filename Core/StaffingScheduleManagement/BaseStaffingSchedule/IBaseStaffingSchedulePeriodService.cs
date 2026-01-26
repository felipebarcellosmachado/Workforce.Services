using Workforce.Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.BaseStaffingSchedule
{
    public interface IBaseStaffingSchedulePeriodService : ICrudService<BaseStaffingSchedulePeriod>
    {
        Task<IList<BaseStaffingSchedulePeriod>> GetAllByBaseStaffingScheduleIdAsync(int baseStaffingScheduleId, CancellationToken ct = default);
    }
}
