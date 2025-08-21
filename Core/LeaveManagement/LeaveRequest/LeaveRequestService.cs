using Workforce.Services;
using Workforce.Domain.Core.LeaveManagement.LeaveRequest.Entity;
using System.Net.Http.Json;

namespace Workforce.Services.Core.LeaveManagement.LeaveRequest
{
    public class LeaveRequestService : CrudService<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>, ILeaveRequestService
    {
        public LeaveRequestService(HttpClient httpClient) 
            : base(httpClient, "api/leave-requests")
        {
        }

        public async Task<IList<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"LeaveRequestService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"LeaveRequestService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"LeaveRequestService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"LeaveRequestService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} entities for environment {environmentId}");
                return result ?? new List<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LeaveRequestService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}