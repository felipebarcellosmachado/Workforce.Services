using Workforce.Domain.Infra.Party.Entity;

namespace Workforce.Services.Infra.Party
{
    public class OrganizationService : CrudService<Organization>, IOrganizationService
    {
        public OrganizationService(HttpClient httpClient) : base(httpClient, "api/infra/party/organization")
        {
        }
    }
}
