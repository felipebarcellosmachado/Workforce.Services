using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.HumanResourceManagement.FunctionalUnit.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.FunctionalUnit
{
    public interface IFunctionalUnitService
    {
        Task<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit> InsertAsync(Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit entity, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit?> UpdateAsync(Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
