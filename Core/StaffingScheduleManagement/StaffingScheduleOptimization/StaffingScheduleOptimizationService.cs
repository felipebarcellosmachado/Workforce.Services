using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Dto;
using Workforce.Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.StaffingScheduleOptimization
{
    public class StaffingScheduleOptimizationService : IStaffingScheduleOptimizationService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/core/staffing-schedule-management/staffing-schedule-optimization";

        public StaffingScheduleOptimizationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>($"{BaseUrl}/{id}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization?> GetDashboardDetailsAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>($"{BaseUrl}/{id}/dashboard-details", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IList<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>> GetAllAsync(CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>>($"{BaseUrl}/all", ct)
                ?? new List<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>();
        }

        public async Task<IList<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>>($"{BaseUrl}/all/environment/{environmentId}", ct)
                ?? new List<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>();
        }

        public async Task<IList<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>> GetAllOpenByEnvironmentIdAsync(int environmentId, int? contextId, CancellationToken ct = default)
        {
            var contextQuery = contextId.HasValue ? $"?contextId={contextId.Value}" : string.Empty;
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>>(
                $"{BaseUrl}/all/environment/{environmentId}/open-contexts{contextQuery}", ct)
                ?? new List<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>();
        }

        public async Task<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization> InsertAsync(Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization entity, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>(cancellationToken: ct)
                ?? throw new InvalidOperationException("Failed to deserialize inserted entity");
        }

        public async Task<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization?> UpdateAsync(Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization entity, CancellationToken ct = default)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>(cancellationToken: ct);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}", ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return false;
            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<StaffingScheduleOptimizationJobResponse> SolveOptimizationAsync(StaffingScheduleOptimizationParameters parameters, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/solve", parameters, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StaffingScheduleOptimizationJobResponse>(cancellationToken: ct)
                ?? throw new InvalidOperationException("Failed to deserialize job response");
        }

        public async Task<StaffingScheduleOptimizationStatusResponse?> GetStatusAsync(int id, CancellationToken ct = default, bool includeDemandCoverage = true)
        {
            try
            {
                var coverageQuery = includeDemandCoverage ? string.Empty : "?includeDemandCoverage=false";
                return await httpClient.GetFromJsonAsync<StaffingScheduleOptimizationStatusResponse>($"{BaseUrl}/{id}/status{coverageQuery}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization?> ResetStatusAsync(int id, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsync($"{BaseUrl}/{id}/reset-status", null, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.StaffingScheduleManagement.StaffingScheduleOptimization.Entity.StaffingScheduleOptimization>(cancellationToken: ct);
        }

        public async Task SaveOptionsAsync(int optimizationId, StaffingScheduleOptimizationOptions options, CancellationToken ct = default)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{optimizationId}/options", options, ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task<StaffingScheduleComparisonResult> CompareAsync(int optimizationAId, int optimizationBId, CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<StaffingScheduleComparisonResult>($"{BaseUrl}/compare/{optimizationAId}/{optimizationBId}", ct)
                ?? throw new InvalidOperationException("Failed to deserialize comparison result");
        }

        public async Task<StaffingScheduleComparisonNarrativeResponse> GetComparisonNarrativeAsync(StaffingScheduleComparisonResult comparison, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/compare/narrative", new StaffingScheduleComparisonNarrativeRequest { Comparison = comparison }, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StaffingScheduleComparisonNarrativeResponse>(cancellationToken: ct)
                ?? throw new InvalidOperationException("Failed to deserialize narrative response");
        }
    }
}
