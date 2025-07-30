using System.Net.Http.Json;

namespace Workforce.Services.Infra.HumanResource.Knowledge
{
    public class KnowledgeService : CrudService<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge>, IKnowledgeService
    {
        public KnowledgeService(HttpClient httpClient) : base(httpClient, "api/infra/humanresource/knowledge")
        {
        }

        public async Task<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge>(_jsonOptions);
                    return result!;
                }
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in KnowledgeService.GetByEnvironmentIdAndId: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge>>(_jsonOptions);
                return result ?? new List<Domain.Infra.HumanResource.Knowledge.Entity.Knowledge>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in KnowledgeService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}