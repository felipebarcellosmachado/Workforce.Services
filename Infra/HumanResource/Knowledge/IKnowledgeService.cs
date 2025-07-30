using Workforce.Domain.Infra.HumanResource.Knowledge.Entity;

namespace Workforce.Services.Infra.HumanResource.Knowledge
{
    public interface IKnowledgeService : ICrudService<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge>
    {
        Task<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge>> GetAllByEnvironmentId(int environmentId);
    }
}