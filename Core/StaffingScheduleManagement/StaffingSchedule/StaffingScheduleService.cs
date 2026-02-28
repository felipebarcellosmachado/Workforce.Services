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

                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}", ct);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>(_jsonOptions, ct);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in StaffingScheduleService.GetByEnvironmentIdAndIdAsync: {ex.Message}");
                throw;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Period
        // ─────────────────────────────────────────────────────────────────────

        public async Task<StaffingSchedulePeriod> InsertPeriodAsync(StaffingSchedulePeriod period, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUri}/period", period, _jsonOptions, ct);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<StaffingSchedulePeriod>(_jsonOptions, ct))!;
        }

        public async Task<StaffingSchedulePeriod?> UpdatePeriodAsync(StaffingSchedulePeriod period, CancellationToken ct = default)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/period/{period.Id}", period, _jsonOptions, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StaffingSchedulePeriod>(_jsonOptions, ct);
        }

        public async Task DeletePeriodAsync(int id, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUri}/period/{id}", ct);
            response.EnsureSuccessStatusCode();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Demand
        // ─────────────────────────────────────────────────────────────────────

        public async Task<StaffingScheduleDemand> InsertDemandAsync(StaffingScheduleDemand demand, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUri}/demand", demand, _jsonOptions, ct);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<StaffingScheduleDemand>(_jsonOptions, ct))!;
        }

        public async Task<StaffingScheduleDemand?> UpdateDemandAsync(StaffingScheduleDemand demand, CancellationToken ct = default)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/demand/{demand.Id}", demand, _jsonOptions, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StaffingScheduleDemand>(_jsonOptions, ct);
        }

        public async Task DeleteDemandAsync(int id, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUri}/demand/{id}", ct);
            response.EnsureSuccessStatusCode();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Resource
        // ─────────────────────────────────────────────────────────────────────

        public async Task<StaffingScheduleResource> InsertResourceAsync(StaffingScheduleResource resource, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUri}/resource", resource, _jsonOptions, ct);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<StaffingScheduleResource>(_jsonOptions, ct))!;
        }

        public async Task<StaffingScheduleResource?> UpdateResourceAsync(StaffingScheduleResource resource, CancellationToken ct = default)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/resource/{resource.Id}", resource, _jsonOptions, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StaffingScheduleResource>(_jsonOptions, ct);
        }

        public async Task DeleteResourceAsync(int id, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUri}/resource/{id}", ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAllResourcesAsync(int staffingScheduleId, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUri}/{staffingScheduleId}/resources", ct);
            response.EnsureSuccessStatusCode();
        }
    }
}
