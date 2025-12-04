using System.Net.Http.Json;
using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public class BaseTourDayService : CrudService<BaseTourScheduleDay>, IBaseTourDayService
    {
        public BaseTourDayService(HttpClient httpClient) 
            : base(httpClient, "api/core/tour-schedule-management/basetourday")
        {
        }

        public async Task<IList<BaseTourScheduleDay>> GetAllByBaseTourScheduleIdAsync(int baseTourScheduleId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseTourDayService.GetAllByBaseTourScheduleIdAsync: Making GET request to {_baseUri}/basetourschedule/{baseTourScheduleId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basetourschedule/{baseTourScheduleId}", ct);
                
                Console.WriteLine($"BaseTourDayService.GetAllByBaseTourScheduleIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseTourDayService.GetAllByBaseTourScheduleIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<BaseTourScheduleDay>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseTourDayService.GetAllByBaseTourScheduleIdAsync: Successfully retrieved {count} BaseTourScheduleDays for BaseTourSchedule {baseTourScheduleId}");
                return result ?? new List<BaseTourScheduleDay>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourDayService.GetAllByBaseTourScheduleIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
