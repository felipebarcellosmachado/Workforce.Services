using System.Net;
using System.Net.Http.Json;
using Entity = Workforce.Domain.Core.ContextManagement.Context.Entity;

namespace Workforce.Services.Core.ContextManagement.Context
{
    public class ContextService : IContextService
    {
        private const string BaseUrl = "api/core/context-management/contexts";
        private readonly HttpClient httpClient;

        public ContextService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Entity.Context?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using var response = await httpClient.GetAsync($"{BaseUrl}/{id}", ct);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await ReadEntityAsync(response, ct);
        }

        public async Task<IList<Entity.Context>> GetAllAsync(CancellationToken ct = default)
        {
            using var response = await httpClient.GetAsync($"{BaseUrl}/all", ct);
            response.EnsureSuccessStatusCode();
            return await ReadListAsync(response, ct);
        }

        public async Task<IList<Entity.Context>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            using var response = await httpClient.GetAsync($"{BaseUrl}/all/environment/{environmentId}", ct);
            response.EnsureSuccessStatusCode();
            return await ReadListAsync(response, ct);
        }

        public async Task<Entity.Context?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default)
        {
            using var response = await httpClient.GetAsync($"{BaseUrl}/environment/{environmentId}/{id}", ct);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await ReadEntityAsync(response, ct);
        }

        public async Task<Entity.Context> InsertAsync(Entity.Context entity, CancellationToken ct = default)
        {
            using var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await ReadEntityAsync(response, ct);
        }

        public async Task<Entity.Context?> UpdateAsync(Entity.Context entity, CancellationToken ct = default)
        {
            using var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await ReadEntityAsync(response, ct);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
        {
            using var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}", ct);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        private static async Task<Entity.Context> ReadEntityAsync(HttpResponseMessage response, CancellationToken ct)
        {
            return await response.Content.ReadFromJsonAsync<Entity.Context>(cancellationToken: ct)
                ?? throw new InvalidDataException("The context API returned an empty response body.");
        }

        private static async Task<IList<Entity.Context>> ReadListAsync(HttpResponseMessage response, CancellationToken ct)
        {
            return await response.Content.ReadFromJsonAsync<IList<Entity.Context>>(cancellationToken: ct)
                ?? throw new InvalidDataException("The context API returned an empty list response.");
        }
    }
}
