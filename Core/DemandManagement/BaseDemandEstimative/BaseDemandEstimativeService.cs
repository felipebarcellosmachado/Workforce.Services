using System.Text.Json;

namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public class BaseDemandEstimativeService : CrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>, IBaseDemandEstimativeService
    {
        public BaseDemandEstimativeService(HttpClient httpClient) : base(httpClient, "api/core/demand-management/base-demand-estimatives")
        {
        }

        public async Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync(ct);
            var result = JsonSerializer.Deserialize<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>>(json, _jsonOptions);
            
            return result ?? new List<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>();
        }
    }
}