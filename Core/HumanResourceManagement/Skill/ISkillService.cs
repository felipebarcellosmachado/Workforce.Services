using Workforce.Services;

namespace Workforce.Services.Infra.HumanResource.Skill
{
    public interface ISkillService : ICrudService<Domain.Core.HumanResourceManagement.Skill.Entity.Skill>
    {
        Task<IList<Domain.Core.HumanResourceManagement.Skill.Entity.Skill>> GetAllByEnvironmentId(int environmentId);
    }
}