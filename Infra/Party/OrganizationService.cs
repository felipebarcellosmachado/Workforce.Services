using System.Net.Http.Json;
using Workforce.Domain.Infra.Party.Entity;

namespace Workforce.Services.Infra.Party
{
    public class OrganizationService : CrudService<Organization>, IOrganizationService
    {
        public OrganizationService(HttpClient httpClient) : base(httpClient, "api/infra/party/organization")
        {
        }

        public async Task<IList<Organization>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Organization>>(_jsonOptions);
                return result ?? new List<Organization>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OrganizationService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}
