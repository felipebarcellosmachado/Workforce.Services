namespace Workforce.Services.Core.HumanResourceManagement.HumanResource
{
    public interface IHumanResourceService : ICrudService<Domain.Core.HumanResourceManagement.HumanResource.Entity.HumanResource>
    {
        Task<IList<Domain.Core.HumanResourceManagement.HumanResource.Entity.HumanResource>> GetAllByEnvironmentId(int environmentId);
    }
}