using Workforce.Domain.Infra.Role.Entity;

namespace Workforce.Services.Infra.Role.Facility
{
    public class FacilityService : CrudService<Domain.Infra.Role.Entity.Facility>, IFacilityService
    {
        public FacilityService(HttpClient httpClient) : base(httpClient, "api/infra/role/facility")
        {
        }
    }
}