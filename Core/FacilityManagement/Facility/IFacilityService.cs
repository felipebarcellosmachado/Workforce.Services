namespace Workforce.Services.Core.FacilityManagement.Facility
{
    public interface IFacilityService : ICrudService<Domain.Core.FacilityManagement.Facility.Entity.Facility>
    {
        Task<IList<Domain.Core.FacilityManagement.Facility.Entity.Facility>> GetAllByEnvironmentId(int environmentId);
    }
}