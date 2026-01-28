using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.HumanResourceManagement.Class.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.Class
{
    public class ClassService : IClassService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/core/human-resource-management/class";

        public ClassService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Domain.Core.HumanResourceManagement.Class.Entity.Class?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.HumanResourceManagement.Class.Entity.Class>($"{BaseUrl}/{id}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.Class.Entity.Class>> GetAllAsync(CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.HumanResourceManagement.Class.Entity.Class>>($"{BaseUrl}/all", ct) ?? new List<Domain.Core.HumanResourceManagement.Class.Entity.Class>();
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.Class.Entity.Class>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.HumanResourceManagement.Class.Entity.Class>>($"{BaseUrl}/all/environment/{environmentId}", ct) ?? new List<Domain.Core.HumanResourceManagement.Class.Entity.Class>();
        }

        public async Task<Domain.Core.HumanResourceManagement.Class.Entity.Class> InsertAsync(Domain.Core.HumanResourceManagement.Class.Entity.Class entity, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Class.Entity.Class>(cancellationToken: ct);
        }

        public async Task<Domain.Core.HumanResourceManagement.Class.Entity.Class?> UpdateAsync(Domain.Core.HumanResourceManagement.Class.Entity.Class entity, CancellationToken ct = default)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Class.Entity.Class>(cancellationToken: ct);
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
