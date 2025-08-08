using Workforce.Services;
using Workforce.Domain.Infra.HumanResource.Qualification.Entity;

namespace Workforce.Services.Infra.HumanResource.Qualification
{
    public interface IQualificationService : ICrudService<Domain.Infra.HumanResource.Qualification.Entity.Qualification>
    {
        Task<IList<Domain.Infra.HumanResource.Qualification.Entity.Qualification>> GetAllByEnvironmentId(int environmentId);
        Task<Domain.Infra.HumanResource.Qualification.Entity.Qualification> GetByEnvironmentIdAndId(int environmentId, int id);
    }
}