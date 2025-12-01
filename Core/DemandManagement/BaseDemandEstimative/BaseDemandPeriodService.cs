using System.Net.Http.Json;

namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public class BaseDemandPeriodService : CrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandPeriod>, IBaseDemandPeriodService
    {
        public BaseDemandPeriodService(HttpClient httpClient) 
            : base(httpClient, "api/core/demand-management/basedemandperiod")
        {
        }

        public async Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandPeriod>> GetAllByBaseDemandDayIdAsync(int baseDemandDayId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseDemandPeriodService.GetAllByBaseDemandDayIdAsync: Making GET request to {_baseUri}/basedemandday/{baseDemandDayId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basedemandday/{baseDemandDayId}", ct);
                
                Console.WriteLine($"BaseDemandPeriodService.GetAllByBaseDemandDayIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseDemandPeriodService.GetAllByBaseDemandDayIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandPeriod>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseDemandPeriodService.GetAllByBaseDemandDayIdAsync: Successfully retrieved {count} BaseDemandPeriods for BaseDemandDay {baseDemandDayId}");
                return result ?? new List<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandPeriod>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseDemandPeriodService.GetAllByBaseDemandDayIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
