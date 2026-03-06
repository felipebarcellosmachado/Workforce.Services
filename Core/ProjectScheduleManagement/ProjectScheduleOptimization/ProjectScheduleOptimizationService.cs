using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Dto;

namespace Workforce.Services.Core.ProjectScheduleManagement.ProjectScheduleOptimization
{
    public class ProjectScheduleOptimizationService : IProjectScheduleOptimizationService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/core/project-schedule-management/project-schedule-optimization";

        public ProjectScheduleOptimizationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>($"{BaseUrl}/{id}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization?> GetByIdForDashboardAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>($"{BaseUrl}/{id}/dashboard", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IList<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>> GetAllAsync(CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>>($"{BaseUrl}/all", ct)
                ?? new List<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>();
        }

        public async Task<IList<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>> GetAllByProjectIdAsync(int projectId, CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>>($"{BaseUrl}/all/project/{projectId}", ct)
                ?? new List<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>();
        }

        public async Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization> InsertAsync(
            Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization entity,
            CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>(cancellationToken: ct)
                ?? throw new InvalidOperationException("Failed to deserialize inserted entity");
        }

        public async Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization?> UpdateAsync(
            Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization entity,
            CancellationToken ct = default)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>(cancellationToken: ct);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}", ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return false;
            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<ProjectScheduleOptimizationJobResponse> SolveOptimizationAsync(
            ProjectScheduleOptimizationParameters parameters,
            CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/solve", parameters, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProjectScheduleOptimizationJobResponse>(cancellationToken: ct)
                ?? throw new InvalidOperationException("Failed to deserialize job response");
        }

        public async Task<ProjectScheduleOptimizationStatusResponse?> GetStatusAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<ProjectScheduleOptimizationStatusResponse>($"{BaseUrl}/{id}/status", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization?> ResetStatusAsync(int id, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsync($"{BaseUrl}/{id}/reset-status", null, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.ProjectScheduleManagement.ProjectScheduleOptimization.Entity.ProjectScheduleOptimization>(cancellationToken: ct);
        }
    }
}
