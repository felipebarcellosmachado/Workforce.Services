using Workforce.Services;
using Workforce.Domain.Core.LeaveManagement.LeaveTake.Entity;
using System.Net.Http.Json;

namespace Workforce.Services.Core.LeaveManagement.LeaveTake
{
    public class LeaveTakeService : CrudService<Domain.Core.LeaveManagement.LeaveTake.Entity.LeaveTake>, ILeaveTakeService
    {
        public LeaveTakeService(HttpClient httpClient) 
            : base(httpClient, "api/leave-takes")
        {
        }

        public async Task<IList<Domain.Core.LeaveManagement.LeaveTake.Entity.LeaveTake>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"LeaveTakeService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"LeaveTakeService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"LeaveTakeService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.LeaveManagement.LeaveTake.Entity.LeaveTake>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"LeaveTakeService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} entities for environment {environmentId}");
                return result ?? new List<Domain.Core.LeaveManagement.LeaveTake.Entity.LeaveTake>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LeaveTakeService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}