using Workforce.Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.StaffingSchedule
{
    public interface IStaffingScheduleService : ICrudService<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>
    {
        Task<IList<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);
    }
}
