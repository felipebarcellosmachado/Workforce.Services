using System.Net.Http.Json;
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
            try
            {
                if (environmentId <= 0)
                {
                    throw new ArgumentException("Environment ID deve ser maior que zero.", nameof(environmentId));
                }

                Console.WriteLine($"BaseDemandEstimativeService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"BaseDemandEstimativeService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseDemandEstimativeService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseDemandEstimativeService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} estimatives for environment {environmentId}");
                return result ?? new List<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseDemandEstimativeService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                if (environmentId <= 0) throw new ArgumentException("EnvironmentId must be greater than zero", nameof(environmentId));
                
                Console.WriteLine($"BaseDemandEstimativeService.GetByEnvironmentIdAndIdAsync: Making GET request to {_baseUri}/environment/{environmentId}/{id}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}", ct);
                
                Console.WriteLine($"BaseDemandEstimativeService.GetByEnvironmentIdAndIdAsync: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"BaseDemandEstimativeService.GetByEnvironmentIdAndIdAsync: BaseDemandEstimative with ID {id} not found for environment {environmentId}");
                    return null;
                }
                    
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>(_jsonOptions, ct);
                Console.WriteLine($"BaseDemandEstimativeService.GetByEnvironmentIdAndIdAsync: Successfully retrieved estimative {id} for environment {environmentId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseDemandEstimativeService.GetByEnvironmentIdAndIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}