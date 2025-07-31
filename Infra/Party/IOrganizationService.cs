using Workforce.Domain.Infra.Party.Entity;

namespace Workforce.Services.Infra.Party
{
    public interface IOrganizationService : ICrudService<Organization>
    {
        Task<IList<Organization>> GetAllByEnvironmentId(int environmentId);
    }
}
