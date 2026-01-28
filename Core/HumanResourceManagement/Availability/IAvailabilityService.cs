using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.HumanResourceManagement.Availability.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.Availability
{
    public interface IAvailabilityService
    {
        Task<Domain.Core.HumanResourceManagement.Availability.Entity.Availability?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>> GetByHumanResourceIdAsync(int humanResourceId, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.Availability.Entity.Availability> InsertAsync(Domain.Core.HumanResourceManagement.Availability.Entity.Availability entity, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.Availability.Entity.Availability?> UpdateAsync(Domain.Core.HumanResourceManagement.Availability.Entity.Availability entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
