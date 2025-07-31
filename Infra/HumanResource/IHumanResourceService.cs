using Workforce.Services;
using Workforce.Domain.Infra.Role.Entity;

namespace Workforce.Services.Infra.HumanResource
{
    public interface IHumanResourceService : ICrudService<Domain.Infra.Role.Entity.HumanResource>
    {
        Task<IList<Domain.Infra.Role.Entity.HumanResource>> GetAllByEnvironmentId(int environmentId);
    }
}