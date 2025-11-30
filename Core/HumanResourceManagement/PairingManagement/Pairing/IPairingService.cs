namespace Workforce.Services.Core.HumanResourceManagement.PairingManagement.Pairing
{
    public interface IPairingService : ICrudService<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing>
    {
        Task<IList<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);
    }
}
