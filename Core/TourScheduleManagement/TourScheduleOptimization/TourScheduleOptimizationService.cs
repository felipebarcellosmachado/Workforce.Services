using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity;
using Workforce.Domain.Core.TourScheduleManagement.TourScheduleOptimization.Dto;

namespace Workforce.Services.Core.TourScheduleManagement.TourScheduleOptimization
{
    public class TourScheduleOptimizationService : ITourScheduleOptimizationService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/core/tour-schedule-management/tour-schedule-optimization";

        public TourScheduleOptimizationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>($"{BaseUrl}/{id}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IList<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>> GetAllAsync(CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>>($"{BaseUrl}/all", ct) ?? new List<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>();
        }

        public async Task<IList<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>>($"{BaseUrl}/all/environment/{environmentId}", ct) ?? new List<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>();
        }

        public async Task<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization> InsertAsync(Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization entity, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>(cancellationToken: ct) ?? throw new InvalidOperationException("Failed to deserialize inserted entity");
        }

        public async Task<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization?> UpdateAsync(Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization entity, CancellationToken ct = default)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>(cancellationToken: ct);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}", ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return false;
            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<IList<TourScheduleAssignment>> SolveOptimizationAsync(TourScheduleOptimizationParameters parameters, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseUrl}/solve", parameters, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<TourScheduleAssignment>>(cancellationToken: ct) ?? new List<TourScheduleAssignment>();
        }

        public async Task<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization?> ResetStatusAsync(int id, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsync($"{BaseUrl}/{id}/reset-status", null, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.TourScheduleManagement.TourScheduleOptimization.Entity.TourScheduleOptimization>(cancellationToken: ct);
        }
    }
}
