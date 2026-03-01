using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.StaffingScheduleOptimization
{
    public interface IStaffingScheduleOptimizationService
    {
        Task<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization> InsertAsync(Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization entity, CancellationToken ct = default);
        Task<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization?> UpdateAsync(Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
