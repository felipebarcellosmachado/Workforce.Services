using System.Net.Http.Json;
using System.Text.Json;
using Workforce.Domain.Core.TourScheduleManagement.TourSchedule.Entity;

namespace Workforce.Services.Core.TourScheduleManagement.TourSchedule
{
    public class TourScheduleService : CrudService<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule>, ITourScheduleService
    {
        public TourScheduleService(HttpClient httpClient) : base(httpClient, "api/core/tour-schedule-management/tourschedule")
        {
        }

        public async Task<IList<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                if (environmentId <= 0)
                {
                    throw new ArgumentException("Environment ID deve ser maior que zero.", nameof(environmentId));
                }

                Console.WriteLine($"TourScheduleService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");

                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);

                Console.WriteLine($"TourScheduleService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"TourScheduleService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"TourScheduleService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} TourSchedules for environment {environmentId}");
                return result ?? new List<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TourScheduleService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                if (environmentId <= 0) throw new ArgumentException("EnvironmentId must be greater than zero", nameof(environmentId));

                Console.WriteLine($"TourScheduleService.GetByEnvironmentIdAndIdAsync: Making GET request to {_baseUri}/environment/{environmentId}/{id}");

                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}", ct);

                Console.WriteLine($"TourScheduleService.GetByEnvironmentIdAndIdAsync: Response status: {response.StatusCode}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"TourScheduleService.GetByEnvironmentIdAndIdAsync: TourSchedule with ID {id} not found for environment {environmentId}");
                    return null;
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Domain.Core.TourScheduleManagement.TourSchedule.Entity.TourSchedule>(_jsonOptions, ct);
                Console.WriteLine($"TourScheduleService.GetByEnvironmentIdAndIdAsync: Successfully retrieved TourSchedule {id} for environment {environmentId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TourScheduleService.GetByEnvironmentIdAndIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
