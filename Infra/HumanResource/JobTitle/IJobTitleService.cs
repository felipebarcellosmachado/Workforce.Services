using Workforce.Domain.Infra.HumanResource.JobTitle.Entity;

namespace Workforce.Services.Infra.HumanResource.JobTitle
{
    public interface IJobTitleService : ICrudService<Domain.Infra.HumanResource.JobTitle.Entity.JobTitle>
    {
        Task<IList<Domain.Infra.HumanResource.JobTitle.Entity.JobTitle>> GetAllByEnvironmentId(int environmentId);
    }
}