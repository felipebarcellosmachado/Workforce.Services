using System.Net.Http.Json;
using System.Text.Json;
using Workforce.Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.BaseStaffingSchedule
{
    public class BaseStaffingScheduleService : CrudService<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule>, IBaseStaffingScheduleService
    {
        public BaseStaffingScheduleService(HttpClient httpClient) : base(httpClient, "api/core/staffing-schedule-management/basestaffingschedule")
        {
        }

        public async Task<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                if (environmentId <= 0)
                {
                    throw new ArgumentException("Environment ID deve ser maior que zero.", nameof(environmentId));
                }

                Console.WriteLine($"BaseStaffingScheduleService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"BaseStaffingScheduleService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseStaffingScheduleService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseStaffingScheduleService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} schedules for environment {environmentId}");
                return result ?? new List<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingScheduleService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                if (environmentId <= 0) throw new ArgumentException("EnvironmentId must be greater than zero", nameof(environmentId));
                
                Console.WriteLine($"BaseStaffingScheduleService.GetByEnvironmentIdAndIdAsync: Making GET request to {_baseUri}/environment/{environmentId}/{id}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}", ct);
                
                Console.WriteLine($"BaseStaffingScheduleService.GetByEnvironmentIdAndIdAsync: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"BaseStaffingScheduleService.GetByEnvironmentIdAndIdAsync: BaseStaffingSchedule with ID {id} not found for environment {environmentId}");
                    return null;
                }
                    
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingSchedule>(_jsonOptions, ct);
                Console.WriteLine($"BaseStaffingScheduleService.GetByEnvironmentIdAndIdAsync: Successfully retrieved schedule {id} for environment {environmentId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingScheduleService.GetByEnvironmentIdAndIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
