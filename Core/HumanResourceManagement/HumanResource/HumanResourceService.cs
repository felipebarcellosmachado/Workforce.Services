using System.Net.Http.Json;

namespace Workforce.Services.Core.HumanResourceManagement.HumanResource
{
    public class HumanResourceService : CrudService<Domain.Core.HumanResourceManagement.HumanResource.Entity.HumanResource>, IHumanResourceService
    {
        public HumanResourceService(HttpClient httpClient) : base(httpClient, "api/infra/humanresource")
        {
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.HumanResource.Entity.HumanResource>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.HumanResource.Entity.HumanResource>>(_jsonOptions);
                return result ?? new List<Domain.Core.HumanResourceManagement.HumanResource.Entity.HumanResource>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in HumanResourceService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}