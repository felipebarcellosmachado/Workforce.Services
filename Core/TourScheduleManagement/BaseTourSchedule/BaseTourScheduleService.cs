using System.Net.Http.Json;
using System.Text.Json;
using Workforce.Domain.Core.TourScheduleManagement.BaseTourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.BaseTourSchedule
{
    public class BaseTourScheduleService : CrudService<BaseTourScheduleEstimative>, IBaseTourScheduleService
    {
        public BaseTourScheduleService(HttpClient httpClient) : base(httpClient, "api/core/tour-schedule-management/basetourscheduleestimative")
        {
        }

        public async Task<IList<BaseTourScheduleEstimative>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                if (environmentId <= 0)
                {
                    throw new ArgumentException("Environment ID deve ser maior que zero.", nameof(environmentId));
                }

                Console.WriteLine($"BaseTourScheduleService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"BaseTourScheduleService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"BaseTourScheduleService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<BaseTourScheduleEstimative>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"BaseTourScheduleService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} estimatives for environment {environmentId}");
                return result ?? new List<BaseTourScheduleEstimative>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourScheduleService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<BaseTourScheduleEstimative?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                if (environmentId <= 0) throw new ArgumentException("EnvironmentId must be greater than zero", nameof(environmentId));
                
                Console.WriteLine($"BaseTourScheduleService.GetByEnvironmentIdAndIdAsync: Making GET request to {_baseUri}/environment/{environmentId}/{id}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}", ct);
                
                Console.WriteLine($"BaseTourScheduleService.GetByEnvironmentIdAndIdAsync: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"BaseTourScheduleService.GetByEnvironmentIdAndIdAsync: BaseTourScheduleEstimative with ID {id} not found for environment {environmentId}");
                    return null;
                }
                    
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<BaseTourScheduleEstimative>(_jsonOptions, ct);
                Console.WriteLine($"BaseTourScheduleService.GetByEnvironmentIdAndIdAsync: Successfully retrieved estimative {id} for environment {environmentId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseTourScheduleService.GetByEnvironmentIdAndIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
