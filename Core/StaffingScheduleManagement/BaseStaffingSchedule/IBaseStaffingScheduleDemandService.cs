using Workforce.Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.BaseStaffingSchedule
{
    public interface IBaseStaffingScheduleDemandService : ICrudService<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>
    {
        Task<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>> GetAllByBaseStaffingScheduleIdAsync(int baseStaffingScheduleId, CancellationToken ct = default);
        Task<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>> GetAllByBaseStaffingSchedulePeriodIdAsync(int baseStaffingSchedulePeriodId, CancellationToken ct = default);
    }
}
