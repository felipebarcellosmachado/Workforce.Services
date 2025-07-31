using Workforce.Domain.Infra.WorkUnit.Entity;

namespace Workforce.Services.Infra.WorkUnit
{
    public class WorkUnitService : CrudService<Domain.Infra.WorkUnit.Entity.WorkUnit>, IWorkUnitService
    {
        public WorkUnitService(HttpClient httpClient) : base(httpClient, "api/infra/workunit")
        {
        }
    }
}