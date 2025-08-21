using System.Net.Http;
using Workforce.Services.Infra;

namespace Workforce.Services.Core.FacilityManagement.WorkUnit
{
    public class WorkUnitService : CrudService<Workforce.Domain.Core.FacilityManagement.WorkUnit.Entity.WorkUnit>, IWorkUnitService
    {
        public WorkUnitService(HttpClient httpClient) : base(httpClient, "api/core/workunit")
        {
        }
    }
}