using System.Net.Http;
using Workforce.Domain.Infra.Environment.Entity;

namespace Workforce.Services.Infra.Environment
{
    public class WorkUnitService : CrudService<Domain.Infra.Environment.Entity.Environment>, IEnvironmentService
    {
        public WorkUnitService(HttpClient httpClient) : base(httpClient, "api/infra/Environment")
        {
        }
    }
}
