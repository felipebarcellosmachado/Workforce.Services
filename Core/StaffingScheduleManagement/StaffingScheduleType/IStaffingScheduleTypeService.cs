using StaffingScheduleTypeEntity = Workforce.Domain.Core.StaffingScheduleManagement.StaffingScheduleType.Entity.StaffingScheduleType;

namespace Workforce.Services.Core.StaffingScheduleManagement.StaffingScheduleType;

public interface IStaffingScheduleTypeService
{
    Task<StaffingScheduleTypeEntity?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IList<StaffingScheduleTypeEntity>> GetAllAsync(CancellationToken ct = default);
    Task<IList<StaffingScheduleTypeEntity>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    Task<StaffingScheduleTypeEntity> InsertAsync(StaffingScheduleTypeEntity entity, CancellationToken ct = default);
    Task<StaffingScheduleTypeEntity?> UpdateAsync(StaffingScheduleTypeEntity entity, CancellationToken ct = default);
    Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
}