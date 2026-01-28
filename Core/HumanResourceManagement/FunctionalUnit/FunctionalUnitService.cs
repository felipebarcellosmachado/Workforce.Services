using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.HumanResourceManagement.FunctionalUnit.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.FunctionalUnit
{
    public class FunctionalUnitService : IFunctionalUnitService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/core/human-resource-management/functionalunit";

        public FunctionalUnitService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>($"{BaseUrl}/{id}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>> GetAllAsync(CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>>($"{BaseUrl}/all", ct) ?? new List<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>();
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>>($"{BaseUrl}/all/environment/{environmentId}", ct) ?? new List<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>();
        }

        public async Task<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit> InsertAsync(Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit entity, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>(cancellationToken: ct);
        }

        public async Task<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit?> UpdateAsync(Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit entity, CancellationToken ct = default)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.FunctionalUnit.Entity.FunctionalUnit>(cancellationToken: ct);
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
