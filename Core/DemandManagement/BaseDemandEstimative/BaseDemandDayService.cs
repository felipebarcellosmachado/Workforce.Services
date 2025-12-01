using System.Net.Http.Json;

namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public class BaseDemandDayService : CrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandDay>, IBaseDemandDayService
    {
        public BaseDemandDayService(HttpClient httpClient) 
            : base(httpClient, "api/core/demand-management/basedemandday")
        {
        }

        public async Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandDay>> GetAllByBaseDemandEstimativeIdAsync(int baseDemandEstimativeId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseDemandDayService.GetAllByBaseDemandEstimativeIdAsync: Making GET request to {_baseUri}/basedemandestimative/{baseDemandEstimativeId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basedemandestimative/{baseDemandEstimativeId}", ct);
                
                Console.WriteLine($"BaseDemandDayService.GetAllByBaseDemandEstimativeIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseDemandDayService.GetAllByBaseDemandEstimativeIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandDay>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseDemandDayService.GetAllByBaseDemandEstimativeIdAsync: Successfully retrieved {count} BaseDemandDays for BaseDemandEstimative {baseDemandEstimativeId}");
                return result ?? new List<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandDay>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseDemandDayService.GetAllByBaseDemandEstimativeIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
