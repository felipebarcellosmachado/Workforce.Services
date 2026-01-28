using Workforce.Domain.Infra.Party.Entity;

namespace Workforce.Services.Infra.Party
{
    public interface IOrganizationService : ICrudService<Organization>
    {
        Task<IList<Organization>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Organization> GetByNameAsync(string name, CancellationToken ct = default);
        Task<Organization> GetByEnvironmentIdAndNameAsync(int environmentId, string name, CancellationToken ct = default);
    }
}
