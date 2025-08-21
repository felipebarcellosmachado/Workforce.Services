namespace Workforce.Services.Core.HumanResourceManagement.Qualification
{
    public interface IQualificationService : ICrudService<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification>
    {
        Task<IList<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification>> GetAllByEnvironmentId(int environmentId);
        Task<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification> GetByEnvironmentIdAndId(int environmentId, int id);
    }
}