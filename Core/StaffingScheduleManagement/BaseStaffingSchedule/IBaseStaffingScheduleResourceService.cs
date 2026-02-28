using Workforce.Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.BaseStaffingSchedule
{
    public interface IBaseStaffingScheduleResourceService : ICrudService<BaseStaffingScheduleResource>
    {
        Task<IList<BaseStaffingScheduleResource>> GetAllByBaseStaffingScheduleIdAsync(int baseStaffingScheduleId, CancellationToken ct = default);
        Task<IList<BaseStaffingScheduleResource>> InsertBatchAsync(IList<BaseStaffingScheduleResource> entities, CancellationToken ct = default);
        Task DeleteAllByBaseStaffingScheduleIdAsync(int baseStaffingScheduleId, CancellationToken ct = default);
    }
}
