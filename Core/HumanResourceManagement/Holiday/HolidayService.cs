using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.WorkManagement.Holiday.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.Holiday
{
    public class HolidayService : IHolidayService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/core/human-resource-management/holiday";

        public HolidayService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Domain.Core.WorkManagement.Holiday.Entity.Holiday?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.WorkManagement.Holiday.Entity.Holiday>($"{BaseUrl}/{id}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IList<Domain.Core.WorkManagement.Holiday.Entity.Holiday>> GetAllAsync(CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.WorkManagement.Holiday.Entity.Holiday>>($"{BaseUrl}/all", ct) ?? new List<Domain.Core.WorkManagement.Holiday.Entity.Holiday>();
        }

        public async Task<IList<Domain.Core.WorkManagement.Holiday.Entity.Holiday>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.WorkManagement.Holiday.Entity.Holiday>>($"{BaseUrl}/all/environment/{environmentId}", ct) ?? new List<Domain.Core.WorkManagement.Holiday.Entity.Holiday>();
        }

        public async Task<Domain.Core.WorkManagement.Holiday.Entity.Holiday> InsertAsync(Domain.Core.WorkManagement.Holiday.Entity.Holiday entity, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.WorkManagement.Holiday.Entity.Holiday>(cancellationToken: ct) ?? throw new InvalidOperationException("Failed to deserialize response");
        }

        public async Task<Domain.Core.WorkManagement.Holiday.Entity.Holiday?> UpdateAsync(Domain.Core.WorkManagement.Holiday.Entity.Holiday entity, CancellationToken ct = default)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.WorkManagement.Holiday.Entity.Holiday>(cancellationToken: ct);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}", ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return false;
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
