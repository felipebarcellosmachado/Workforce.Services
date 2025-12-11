using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.HumanResourceManagement.Availability.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.Availability
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/core/human-resource-management/availability";

        public AvailabilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Domain.Core.HumanResourceManagement.Availability.Entity.Availability?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>($"{BaseUrl}/{id}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>> GetAllAsync(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<IList<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>>($"{BaseUrl}/all", ct) ?? new List<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>();
        }

        public async Task<Domain.Core.HumanResourceManagement.Availability.Entity.Availability> InsertAsync(Domain.Core.HumanResourceManagement.Availability.Entity.Availability entity, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>(cancellationToken: ct);
        }

        public async Task<Domain.Core.HumanResourceManagement.Availability.Entity.Availability?> UpdateAsync(Domain.Core.HumanResourceManagement.Availability.Entity.Availability entity, CancellationToken ct = default)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Availability.Entity.Availability>(cancellationToken: ct);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}", ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return false;
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
