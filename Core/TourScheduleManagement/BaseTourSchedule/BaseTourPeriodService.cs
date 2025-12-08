using System.Net.Http.Json;
using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public class BaseTourPeriodService : CrudService<BaseTourSchedulePeriod>, IBaseTourPeriodService
    {
        public BaseTourPeriodService(HttpClient httpClient) 
            : base(httpClient, "api/core/tour-schedule-management/basetourscheduleperiod")
        {
        }

        public async Task<IList<BaseTourSchedulePeriod>> GetAllByBaseTourScheduleIdAsync(int baseTourScheduleId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseTourPeriodService.GetAllByBaseTourScheduleIdAsync: Making GET request to {_baseUri}/basetourschedule/{baseTourScheduleId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basetourschedule/{baseTourScheduleId}", ct);
                
                Console.WriteLine($"BaseTourPeriodService.GetAllByBaseTourScheduleIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseTourPeriodService.GetAllByBaseTourScheduleIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<BaseTourSchedulePeriod>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseTourPeriodService.GetAllByBaseTourScheduleIdAsync: Successfully retrieved {count} BaseTourPeriods for BaseTourSchedule {baseTourScheduleId}");
                return result ?? new List<BaseTourSchedulePeriod>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourPeriodService.GetAllByBaseTourScheduleIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
