using System.Net.Http.Json;
using Workforce.Services;

namespace Workforce.Services.Core.LeaveManagement.LeaveType
{
    public class LeaveTypeService : CrudService<Domain.Core.LeaveManagement.LeaveType.Entity.LeaveType>, ILeaveTypeService
    {
        public LeaveTypeService(HttpClient httpClient) 
            : base(httpClient, "api/core/leave-management/leave-type")
        {
        }

        public async Task<IList<Domain.Core.LeaveManagement.LeaveType.Entity.LeaveType>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"LeaveTypeService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"LeaveTypeService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"LeaveTypeService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.LeaveManagement.LeaveType.Entity.LeaveType>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"LeaveTypeService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} leave types for environment {environmentId}");
                return result ?? new List<Domain.Core.LeaveManagement.LeaveType.Entity.LeaveType>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LeaveTypeService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}