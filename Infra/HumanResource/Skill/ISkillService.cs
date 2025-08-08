using Workforce.Services;

namespace Workforce.Services.Infra.HumanResource.Skill
{
    public interface ISkillService : ICrudService<Workforce.Domain.Infra.HumanResource.Skill.Entity.Skill>
    {
        Task<IList<Workforce.Domain.Infra.HumanResource.Skill.Entity.Skill>> GetAllByEnvironmentId(int environmentId);
    }
}