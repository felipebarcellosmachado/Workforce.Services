using Workforce.Domain.Infra.HumanResource.CompetenceLevel.Entity;

namespace Workforce.Services.Infra.HumanResource.CompetenceLevel
{
    public interface ICompetenceLevelService : ICrudService<Domain.Infra.HumanResource.CompetenceLevel.Entity.CompetenceLevel>
    {
        Task<IList<Domain.Infra.HumanResource.CompetenceLevel.Entity.CompetenceLevel>> GetAllByEnvironmentId(int environmentId);
    }
}