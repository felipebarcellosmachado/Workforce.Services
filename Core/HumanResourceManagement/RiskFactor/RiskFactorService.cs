using System.Net.Http.Json;
using System.Net;

namespace Workforce.Services.Core.HumanResourceManagement.RiskFactor
{
    public class RiskFactorService : CrudService<Domain.Core.HumanResourceManagement.RiskFactor.Entity.RiskFactor>, IRiskFactorService
    {
        public RiskFactorService(HttpClient httpClient) : base(httpClient, "api/core/human-resource-management/riskfactor")
        {
        }
    }
}
