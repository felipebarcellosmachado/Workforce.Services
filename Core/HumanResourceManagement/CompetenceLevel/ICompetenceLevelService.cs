namespace Workforce.Services.Infra.HumanResource.CompetenceLevel
{
    public interface ICompetenceLevelService : ICrudService<Domain.Core.HumanResourceManagement.CompetenceLevel.Entity.CompetenceLevel>
    {
        Task<IList<Domain.Core.HumanResourceManagement.CompetenceLevel.Entity.CompetenceLevel>> GetAllByEnvironmentId(int environmentId);
    }
}