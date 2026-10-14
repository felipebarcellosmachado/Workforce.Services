using TourScheduleTypeEntity = Workforce.Domain.Core.TourScheduleManagement.TourScheduleType.Entity.TourScheduleType;

namespace Workforce.Services.Core.TourScheduleManagement.TourScheduleType;

public interface ITourScheduleTypeService
{
    Task<TourScheduleTypeEntity?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IList<TourScheduleTypeEntity>> GetAllAsync(CancellationToken ct = default);
    Task<IList<TourScheduleTypeEntity>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    Task<TourScheduleTypeEntity> InsertAsync(TourScheduleTypeEntity entity, CancellationToken ct = default);
    Task<TourScheduleTypeEntity?> UpdateAsync(TourScheduleTypeEntity entity, CancellationToken ct = default);
    Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
}