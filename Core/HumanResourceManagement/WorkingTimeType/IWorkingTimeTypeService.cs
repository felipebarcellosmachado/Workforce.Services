using WorkingTimeTypeEntity = Workforce.Domain.Core.WorkManagement.WorkingTime.Entity.WorkingTimeType;

namespace Workforce.Services.Core.HumanResourceManagement.WorkingTimeType;

public interface IWorkingTimeTypeService
{
    Task<WorkingTimeTypeEntity?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IList<WorkingTimeTypeEntity>> GetAllAsync(CancellationToken ct = default);
    Task<IList<WorkingTimeTypeEntity>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    Task<WorkingTimeTypeEntity> InsertAsync(WorkingTimeTypeEntity entity, CancellationToken ct = default);
    Task<WorkingTimeTypeEntity?> UpdateAsync(WorkingTimeTypeEntity entity, CancellationToken ct = default);
    Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
}
