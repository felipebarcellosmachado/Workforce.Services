using System.Net.Http.Json;
using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public class BaseTourPeriodService : CrudService<BaseTourSchedulePeriod>, IBaseTourPeriodService
    {
        public BaseTourPeriodService(HttpClient httpClient) 
            : base(httpClient, "api/core/tour-schedule-management/basetourperiod")
        {
        }

        public async Task<IList<BaseTourSchedulePeriod>> GetAllByBaseTourDayIdAsync(int baseTourDayId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseTourPeriodService.GetAllByBaseTourDayIdAsync: Making GET request to {_baseUri}/basetourday/{baseTourDayId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basetourday/{baseTourDayId}", ct);
                
                Console.WriteLine($"BaseTourPeriodService.GetAllByBaseTourDayIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseTourPeriodService.GetAllByBaseTourDayIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<BaseTourSchedulePeriod>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseTourPeriodService.GetAllByBaseTourDayIdAsync: Successfully retrieved {count} BaseTourPeriods for BaseTourDay {baseTourDayId}");
                return result ?? new List<BaseTourSchedulePeriod>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourPeriodService.GetAllByBaseTourDayIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
