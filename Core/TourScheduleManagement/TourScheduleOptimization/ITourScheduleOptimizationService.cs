using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.TourScheduleOptimization
{
    public interface ITourScheduleOptimizationService
    {
        Task<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization> InsertAsync(Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization entity, CancellationToken ct = default);
        Task<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization?> UpdateAsync(Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
