using System.Net.Http.Json;
using Workforce.Domain.Infra.Role.Entity;

namespace Workforce.Services.Infra.HumanResource
{
    public class HumanResourceService : CrudService<Domain.Infra.Role.Entity.HumanResource>, IHumanResourceService
    {
        public HumanResourceService(HttpClient httpClient) : base(httpClient, "api/infra/humanresource")
        {
        }

        public async Task<IList<Domain.Infra.Role.Entity.HumanResource>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.Role.Entity.HumanResource>>(_jsonOptions);
                return result ?? new List<Domain.Infra.Role.Entity.HumanResource>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in HumanResourceService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}