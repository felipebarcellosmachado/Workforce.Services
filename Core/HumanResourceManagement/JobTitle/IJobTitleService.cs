namespace Workforce.Services.Core.HumanResourceManagement.JobTitle
{
    public interface IJobTitleService : ICrudService<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>
    {
        Task<IList<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>> GetAllByEnvironmentId(int environmentId);
    }
}