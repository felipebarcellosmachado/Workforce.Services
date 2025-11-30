using System.Net.Http.Json;

namespace Workforce.Services.Core.HumanResourceManagement.PairingManagement.Pairing
{
    public class PairingService : CrudService<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing>, IPairingService
    {
        public PairingService(HttpClient httpClient) 
            : base(httpClient, "api/core/human_resource_management/pairing_management/pairing")
        {
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"PairingService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"PairingService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"PairingService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"PairingService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} pairings for environment {environmentId}");
                return result ?? new List<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                if (environmentId <= 0) throw new ArgumentException("EnvironmentId must be greater than zero", nameof(environmentId));
                
                Console.WriteLine($"PairingService.GetByEnvironmentIdAndIdAsync: Making GET request to {_baseUri}/environment/{environmentId}/{id}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}", ct);
                
                Console.WriteLine($"PairingService.GetByEnvironmentIdAndIdAsync: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"PairingService.GetByEnvironmentIdAndIdAsync: Pairing with ID {id} not found for environment {environmentId}");
                    return null;
                }
                    
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Pairing.Pairing.Entity.Pairing>(_jsonOptions, ct);
                Console.WriteLine($"PairingService.GetByEnvironmentIdAndIdAsync: Successfully retrieved pairing {id} for environment {environmentId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingService.GetByEnvironmentIdAndIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
