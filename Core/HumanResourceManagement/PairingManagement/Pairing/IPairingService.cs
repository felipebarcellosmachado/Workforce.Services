using Workforce.Domain.Core.PairingManagement.Pairing.Dto;

namespace Workforce.Services.Core.HumanResourceManagement.PairingManagement.Pairing
{
    public interface IPairingService : ICrudService<Domain.Core.PairingManagement.Pairing.Entity.Pairing>
    {
        Task<IList<Domain.Core.PairingManagement.Pairing.Entity.Pairing>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.PairingManagement.Pairing.Entity.Pairing?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);
        Task<IList<PairingListDto>> GetAllListDtoAsync(CancellationToken ct = default);
        Task<IList<PairingListDto>> GetAllListDtoByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    }
}
