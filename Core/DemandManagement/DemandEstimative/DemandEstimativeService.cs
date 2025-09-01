using System.Text.Json;

namespace Workforce.Services.Core.DemandManagement.DemandEstimative
{
    public class DemandEstimativeService : CrudService<Domain.Core.DemandManagement.DemandEstimative.Entity.DemandEstimative>, IDemandEstimativeService
    {
        public DemandEstimativeService(HttpClient httpClient) : base(httpClient, "api/core/demand-management/demand-estimatives")
        {
        }

        public async Task<IList<Domain.Core.DemandManagement.DemandEstimative.Entity.DemandEstimative>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync(ct);
            var result = JsonSerializer.Deserialize<IList<Domain.Core.DemandManagement.DemandEstimative.Entity.DemandEstimative>>(json, _jsonOptions);
            
            return result ?? new List<Domain.Core.DemandManagement.DemandEstimative.Entity.DemandEstimative>();
        }
    }
}