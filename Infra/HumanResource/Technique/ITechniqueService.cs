using Workforce.Domain.Infra.HumanResource.Technique.Entity;

namespace Workforce.Services.Infra.HumanResource.Technique
{
    public interface ITechniqueService : ICrudService<Domain.Infra.HumanResource.Technique.Entity.Technique>
    {
        Task<Domain.Infra.HumanResource.Technique.Entity.Technique> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Infra.HumanResource.Technique.Entity.Technique>> GetAllByEnvironmentId(int environmentId);
    }
}