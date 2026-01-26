using Workforce.Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.BaseStaffingSchedule
{
    public interface IBaseStaffingScheduleService : ICrudService<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule>
    {
        Task<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);
    }
}
