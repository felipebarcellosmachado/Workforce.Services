using System.Net.Http.Json;

namespace Workforce.Services.Infra.HumanResource.Technique
{
    public class TechniqueService : CrudService<Domain.Infra.HumanResource.Technique.Entity.Technique>, ITechniqueService
    {
        public TechniqueService(HttpClient httpClient) : base(httpClient, "api/infra/humanresource/technique")
        {
        }

        public async Task<Domain.Infra.HumanResource.Technique.Entity.Technique> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Domain.Infra.HumanResource.Technique.Entity.Technique>(_jsonOptions);
                    return result!;
                }
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TechniqueService.GetByEnvironmentIdAndId: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Infra.HumanResource.Technique.Entity.Technique>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.HumanResource.Technique.Entity.Technique>>(_jsonOptions);
                return result ?? new List<Domain.Infra.HumanResource.Technique.Entity.Technique>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TechniqueService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}