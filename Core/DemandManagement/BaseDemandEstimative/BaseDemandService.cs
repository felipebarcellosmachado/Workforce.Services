using System.Net.Http.Json;

namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public class BaseDemandService : CrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>, IBaseDemandService
    {
        public BaseDemandService(HttpClient httpClient) 
            : base(httpClient, "api/core/demand-management/basedemand")
        {
        }

        public async Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>> GetAllByBaseDemandEstimativeIdAsync(int baseDemandEstimativeId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseDemandService.GetAllByBaseDemandEstimativeIdAsync: Making GET request to {_baseUri}/basedemandestimative/{baseDemandEstimativeId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basedemandestimative/{baseDemandEstimativeId}", ct);
                
                Console.WriteLine($"BaseDemandService.GetAllByBaseDemandEstimativeIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseDemandService.GetAllByBaseDemandEstimativeIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseDemandService.GetAllByBaseDemandEstimativeIdAsync: Successfully retrieved {count} BaseDemands for BaseDemandEstimative {baseDemandEstimativeId}");
                return result ?? new List<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseDemandService.GetAllByBaseDemandEstimativeIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>> GetAllByBaseDemandPeriodIdAsync(int baseDemandPeriodId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"BaseDemandService.GetAllByBaseDemandPeriodIdAsync: Making GET request to {_baseUri}/basedemandperiod/{baseDemandPeriodId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/basedemandperiod/{baseDemandPeriodId}", ct);
                
                Console.WriteLine($"BaseDemandService.GetAllByBaseDemandPeriodIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseDemandService.GetAllByBaseDemandPeriodIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseDemandService.GetAllByBaseDemandPeriodIdAsync: Successfully retrieved {count} BaseDemands for BaseDemandPeriod {baseDemandPeriodId}");
                return result ?? new List<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseDemandService.GetAllByBaseDemandPeriodIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
