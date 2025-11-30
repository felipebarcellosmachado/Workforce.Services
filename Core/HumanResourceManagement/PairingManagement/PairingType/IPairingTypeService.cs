using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Workforce.Services.Core.HumanResourceManagement.PairingManagement.PairingType
{
    public interface IPairingTypeService
    {
        Task<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType> InsertAsync(Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType entity, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType?> UpdateAsync(Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
