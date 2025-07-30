using Workforce.Domain.Infra.Role.Entity;

namespace Workforce.Services.Infra.Role
{
    public class FacilityService : CrudService<Facility>, IFacilityService
    {
        public FacilityService(HttpClient httpClient) : base(httpClient, "api/infra/role/facility")
        {
        }
    }
}