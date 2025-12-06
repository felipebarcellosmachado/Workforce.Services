using System.Net.Http.Json;
using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public class BaseTourScheduleDemandService : CrudService<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>, IBaseTourScheduleDemandService
    {
        public BaseTourScheduleDemandService(HttpClient httpClient) 
            : base(httpClient, "api/core/tour-schedule-management/basetourscheduledemand")
        {
        }

        public async Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>> GetAllByBaseTourScheduleIdAsync(int baseTourScheduleId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseTourScheduleDemandService.GetAllByBaseTourScheduleIdAsync: Making GET request to {_baseUri}/basetourschedule/{baseTourScheduleId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basetourschedule/{baseTourScheduleId}", ct);
                
                Console.WriteLine($"BaseTourScheduleDemandService.GetAllByBaseTourScheduleIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseTourScheduleDemandService.GetAllByBaseTourScheduleIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseTourScheduleDemandService.GetAllByBaseTourScheduleIdAsync: Successfully retrieved {count} BaseTourScheduleDemands for BaseTourSchedule {baseTourScheduleId}");
                return result ?? new List<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourScheduleDemandService.GetAllByBaseTourScheduleIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>> GetAllByBaseTourSchedulePeriodIdAsync(int baseTourSchedulePeriodId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseTourScheduleDemandService.GetAllByBaseTourSchedulePeriodIdAsync: Making GET request to {_baseUri}/basetourscheduleperiod/{baseTourSchedulePeriodId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basetourscheduleperiod/{baseTourSchedulePeriodId}", ct);
                
                Console.WriteLine($"BaseTourScheduleDemandService.GetAllByBaseTourSchedulePeriodIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseTourScheduleDemandService.GetAllByBaseTourSchedulePeriodIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseTourScheduleDemandService.GetAllByBaseTourSchedulePeriodIdAsync: Successfully retrieved {count} BaseTourScheduleDemands for BaseTourSchedulePeriod {baseTourSchedulePeriodId}");
                return result ?? new List<Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity.BaseTourScheduleDemand>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourScheduleDemandService.GetAllByBaseTourSchedulePeriodIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
