using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Dto;

namespace Workforce.Services.Core.ProjectScheduleManagement.ProjectScheduleOptimization
{
    public interface IProjectScheduleOptimizationService
    {
        Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>> GetAllByProjectIdAsync(int projectId, CancellationToken ct = default);
        Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization> InsertAsync(Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization entity, CancellationToken ct = default);
        Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization?> UpdateAsync(Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
        Task<ProjectScheduleOptimizationJobResponse> SolveOptimizationAsync(ProjectScheduleOptimizationParameters parameters, CancellationToken ct = default);
        Task<ProjectScheduleOptimizationStatusResponse?> GetStatusAsync(int id, CancellationToken ct = default);
        Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization?> ResetStatusAsync(int id, CancellationToken ct = default);
    }
}

