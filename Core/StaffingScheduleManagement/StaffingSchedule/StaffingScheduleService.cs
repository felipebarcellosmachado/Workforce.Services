using System.Net.Http.Json;
using System.Text.Json;
using Workforce.Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.StaffingSchedule
{
    public class StaffingScheduleService : CrudService<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>, IStaffingScheduleService
    {
        public StaffingScheduleService(HttpClient httpClient) : base(httpClient, "api/core/staffing-schedule-management/staffingschedule")
        {
        }

        public async Task<IList<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                if (environmentId <= 0)
                {
                    throw new ArgumentException("Environment ID deve ser maior que zero.", nameof(environmentId));
                }

                Console.WriteLine($"StaffingScheduleService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");

                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);

                Console.WriteLine($"StaffingScheduleService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"StaffingScheduleService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"StaffingScheduleService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} StaffingSchedules for environment {environmentId}");
                return result ?? new List<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in StaffingScheduleService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                if (environmentId <= 0) throw new ArgumentException("EnvironmentId must be greater than zero", nameof(environmentId));

                Console.WriteLine($"StaffingScheduleService.GetByEnvironmentIdAndIdAsync: Making GET request to {_baseUri}/environment/{environmentId}/{id}");

                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}", ct);

                Console.WriteLine($"StaffingScheduleService.GetByEnvironmentIdAndIdAsync: Response status: {response.StatusCode}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"StaffingScheduleService.GetByEnvironmentIdAndIdAsync: StaffingSchedule with ID {id} not found for environment {environmentId}");
                    return null;
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>(_jsonOptions, ct);
                Console.WriteLine($"StaffingScheduleService.GetByEnvironmentIdAndIdAsync: Successfully retrieved StaffingSchedule {id} for environment {environmentId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in StaffingScheduleService.GetByEnvironmentIdAndIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
