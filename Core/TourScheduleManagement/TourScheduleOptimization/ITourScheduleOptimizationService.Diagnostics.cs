using System.Threading;
using System.Threading.Tasks;

namespace Workforce.Services.Core.TourScheduleManagement.TourScheduleOptimization
{
    public partial interface ITourScheduleOptimizationService
    {
        /// <summary>
        /// Obtém relatório de diagnóstico de uso de recursos para uma otimização
        /// </summary>
        Task<string?> GetResourceUsageDiagnosticsAsync(int id, CancellationToken ct = default);
    }
}
