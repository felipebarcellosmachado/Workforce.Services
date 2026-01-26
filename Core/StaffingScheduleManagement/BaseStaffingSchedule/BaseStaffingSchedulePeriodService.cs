using System.Net.Http.Json;
using Workforce.Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.BaseStaffingSchedule
{
    public class BaseStaffingSchedulePeriodService : CrudService<BaseStaffingSchedulePeriod>, IBaseStaffingSchedulePeriodService
    {
        public BaseStaffingSchedulePeriodService(HttpClient httpClient) 
            : base(httpClient, "api/core/staffing-schedule-management/basestaffingscheduleperiod")
        {
        }

        public async Task<IList<BaseStaffingSchedulePeriod>> GetAllByBaseStaffingScheduleIdAsync(int baseStaffingScheduleId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseStaffingSchedulePeriodService.GetAllByBaseStaffingScheduleIdAsync: Making GET request to {_baseUri}/basestaffingschedule/{baseStaffingScheduleId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basestaffingschedule/{baseStaffingScheduleId}", ct);
                
                Console.WriteLine($"BaseStaffingSchedulePeriodService.GetAllByBaseStaffingScheduleIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseStaffingSchedulePeriodService.GetAllByBaseStaffingScheduleIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<BaseStaffingSchedulePeriod>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseStaffingSchedulePeriodService.GetAllByBaseStaffingScheduleIdAsync: Successfully retrieved {count} periods for BaseStaffingSchedule {baseStaffingScheduleId}");
                return result ?? new List<BaseStaffingSchedulePeriod>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingSchedulePeriodService.GetAllByBaseStaffingScheduleIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
