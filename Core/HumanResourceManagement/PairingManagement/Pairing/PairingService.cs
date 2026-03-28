using System.Net.Http.Json;
using Workforce.Domain.Core.PairingManagement.Pairing.Dto;

namespace Workforce.Services.Core.HumanResourceManagement.PairingManagement.Pairing
{
    public class PairingService : CrudService<Domain.Core.PairingManagement.Pairing.Entity.Pairing>, IPairingService
    {
        public PairingService(HttpClient httpClient) 
            : base(httpClient, "api/core/human_resource_management/pairing_management/pairing")
        {
        }

        public async Task<IList<Domain.Core.PairingManagement.Pairing.Entity.Pairing>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
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
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.PairingManagement.Pairing.Entity.Pairing>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"PairingService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} pairings for environment {environmentId}");
                return result ?? new List<Domain.Core.PairingManagement.Pairing.Entity.Pairing>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.PairingManagement.Pairing.Entity.Pairing?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default)
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
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.PairingManagement.Pairing.Entity.Pairing>(_jsonOptions, ct);
                Console.WriteLine($"PairingService.GetByEnvironmentIdAndIdAsync: Successfully retrieved pairing {id} for environment {environmentId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingService.GetByEnvironmentIdAndIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<PairingListDto>> GetAllListDtoAsync(CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"PairingService.GetAllListDtoAsync: Making GET request to {_baseUri}/list/all");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/list/all", ct);
                
                Console.WriteLine($"PairingService.GetAllListDtoAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"PairingService.GetAllListDtoAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<PairingListDto>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"PairingService.GetAllListDtoAsync: Successfully retrieved {count} pairings");
                return result ?? new List<PairingListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingService.GetAllListDtoAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<PairingListDto>> GetAllListDtoByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"PairingService.GetAllListDtoByEnvironmentIdAsync: Making GET request to {_baseUri}/list/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/list/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"PairingService.GetAllListDtoByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"PairingService.GetAllListDtoByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<PairingListDto>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"PairingService.GetAllListDtoByEnvironmentIdAsync: Successfully retrieved {count} pairings for environment {environmentId}");
                return result ?? new List<PairingListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingService.GetAllListDtoByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
