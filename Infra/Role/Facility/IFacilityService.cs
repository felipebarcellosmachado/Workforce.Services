using Workforce.Domain.Infra.Role.Facility.Entity;

namespace Workforce.Services.Infra.Role.Facility
{
    public interface IFacilityService : ICrudService<Domain.Infra.Role.Facility.Entity.Facility>
    {
        Task<IList<Domain.Infra.Role.Facility.Entity.Facility>> GetAllByEnvironmentId(int environmentId);
    }
}