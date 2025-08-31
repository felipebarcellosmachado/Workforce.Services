using Workforce.Domain.Infra.Party.Entity;

namespace Workforce.Services.Infra.Party
{
    public interface IOrganizationService : ICrudService<Organization>
    {
        Task<IList<Organization>> GetAllByEnvironmentId(int environmentId);
        Task<Organization> GetByName(string name);
        Task<Organization> GetByEnvironmentIdAndName(int environmentId, string name);
    }
}
