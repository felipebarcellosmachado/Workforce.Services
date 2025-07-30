using System.Net.Http;
using Workforce.Domain.Infra.Environment.Entity;

namespace Workforce.Services.Infra.Environment
{
    public class EnvironmentService : CrudService<Domain.Infra.Environment.Entity.Environment>, IEnvironmentService
    {
        public EnvironmentService(HttpClient httpClient) : base(httpClient, "api/infra/Environment")
        {
        }
    }
}
