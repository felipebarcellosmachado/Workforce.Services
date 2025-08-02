using Workforce.Services;

namespace Workforce.Services.Infra.HumanResource
{
    public interface IHumanResourceService : ICrudService<Domain.Infra.Role.HumanResource.Entity.HumanResource>
    {
        Task<IList<Domain.Infra.Role.HumanResource.Entity.HumanResource>> GetAllByEnvironmentId(int environmentId);
    }
}