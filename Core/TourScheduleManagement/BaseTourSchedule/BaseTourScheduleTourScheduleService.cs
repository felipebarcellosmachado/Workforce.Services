using System.Net.Http.Json;
using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public class BaseTourScheduleTourScheduleService : CrudService<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>, IBaseTourScheduleTourScheduleService
    {
        public BaseTourScheduleTourScheduleService(HttpClient httpClient) 
            : base(httpClient, "api/core/tour-schedule-management/basetourschedule")
        {
        }

        public async Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>> GetAllByBaseTourScheduleEstimativeIdAsync(int baseTourScheduleEstimativeId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseTourScheduleTourScheduleService.GetAllByBaseTourScheduleEstimativeIdAsync: Making GET request to {_baseUri}/basetourscheduleestimative/{baseTourScheduleEstimativeId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basetourscheduleestimative/{baseTourScheduleEstimativeId}", ct);
                
                Console.WriteLine($"BaseTourScheduleTourScheduleService.GetAllByBaseTourScheduleEstimativeIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseTourScheduleTourScheduleService.GetAllByBaseTourScheduleEstimativeIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseTourScheduleTourScheduleService.GetAllByBaseTourScheduleEstimativeIdAsync: Successfully retrieved {count} BaseTourSchedules for BaseTourScheduleEstimative {baseTourScheduleEstimativeId}");
                return result ?? new List<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourScheduleTourScheduleService.GetAllByBaseTourScheduleEstimativeIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>> GetAllByBaseTourSchedulePeriodIdAsync(int baseTourSchedulePeriodId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseTourScheduleTourScheduleService.GetAllByBaseTourSchedulePeriodIdAsync: Making GET request to {_baseUri}/basetourscheduleperiod/{baseTourSchedulePeriodId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basetourscheduleperiod/{baseTourSchedulePeriodId}", ct);
                
                Console.WriteLine($"BaseTourScheduleTourScheduleService.GetAllByBaseTourSchedulePeriodIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseTourScheduleTourScheduleService.GetAllByBaseTourSchedulePeriodIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseTourScheduleTourScheduleService.GetAllByBaseTourSchedulePeriodIdAsync: Successfully retrieved {count} BaseTourSchedules for BaseTourSchedulePeriod {baseTourSchedulePeriodId}");
                return result ?? new List<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourSchedule>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourScheduleTourScheduleService.GetAllByBaseTourSchedulePeriodIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
