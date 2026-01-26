using System.Net.Http.Json;
using Workforce.Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.BaseStaffingSchedule
{
    public class BaseStaffingScheduleDemandService : CrudService<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>, IBaseStaffingScheduleDemandService
    {
        public BaseStaffingScheduleDemandService(HttpClient httpClient) 
            : base(httpClient, "api/core/staffing-schedule-management/basestaffingscheduledemand")
        {
        }

        public async Task<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>> GetAllByBaseStaffingScheduleIdAsync(int baseStaffingScheduleId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseStaffingScheduleDemandService.GetAllByBaseStaffingScheduleIdAsync: Making GET request to {_baseUri}/basestaffingschedule/{baseStaffingScheduleId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basestaffingschedule/{baseStaffingScheduleId}", ct);
                
                Console.WriteLine($"BaseStaffingScheduleDemandService.GetAllByBaseStaffingScheduleIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseStaffingScheduleDemandService.GetAllByBaseStaffingScheduleIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseStaffingScheduleDemandService.GetAllByBaseStaffingScheduleIdAsync: Successfully retrieved {count} demands for BaseStaffingSchedule {baseStaffingScheduleId}");
                return result ?? new List<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingScheduleDemandService.GetAllByBaseStaffingScheduleIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>> GetAllByBaseStaffingSchedulePeriodIdAsync(int baseStaffingSchedulePeriodId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseStaffingScheduleDemandService.GetAllByBaseStaffingSchedulePeriodIdAsync: Making GET request to {_baseUri}/basestaffingscheduleperiod/{baseStaffingSchedulePeriodId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basestaffingscheduleperiod/{baseStaffingSchedulePeriodId}", ct);
                
                Console.WriteLine($"BaseStaffingScheduleDemandService.GetAllByBaseStaffingSchedulePeriodIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseStaffingScheduleDemandService.GetAllByBaseStaffingSchedulePeriodIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseStaffingScheduleDemandService.GetAllByBaseStaffingSchedulePeriodIdAsync: Successfully retrieved {count} demands for BaseStaffingSchedulePeriod {baseStaffingSchedulePeriodId}");
                return result ?? new List<Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity.BaseStaffingScheduleDemand>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingScheduleDemandService.GetAllByBaseStaffingSchedulePeriodIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
