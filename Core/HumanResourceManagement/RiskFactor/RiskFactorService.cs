using System.Net.Http.Json;
using System.Net;

namespace Workforce.Services.Core.HumanResourceManagement.RiskFactor
{
    public class RiskFactorService : CrudService<Domain.Core.HumanResourceManagement.RiskFactor.Entity.RiskFactor>, IRiskFactorService
    {
        public RiskFactorService(HttpClient httpClient) : base(httpClient, "api/core/human-resource-management/riskfactor")
        {
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.RiskFactor.Entity.RiskFactor>> GetAllByEnvironmentIdAsync(int environmentId)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.RiskFactor.Entity.RiskFactor>>(_jsonOptions) 
                   ?? new List<Domain.Core.HumanResourceManagement.RiskFactor.Entity.RiskFactor>();
        }
    }
}
