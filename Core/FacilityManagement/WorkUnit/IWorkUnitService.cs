namespace Workforce.Services.Core.FacilityManagement.WorkUnit
{
    public interface IWorkUnitService : ICrudService<Domain.Core.FacilityManagement.WorkUnit.Entity.WorkUnit>
    {
        Task<IList<Domain.Core.FacilityManagement.WorkUnit.Entity.WorkUnit>> GetAllByEnvironmentId(int environmentId);
    }
}