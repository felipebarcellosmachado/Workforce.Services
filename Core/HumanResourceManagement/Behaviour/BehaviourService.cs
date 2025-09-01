using System.Net.Http.Json;

namespace Workforce.Services.Core.HumanResourceManagement.Behaviour
{
    public class BehaviourService : CrudService<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour>, IBehaviourService
    {
        public BehaviourService(HttpClient httpClient) : base(httpClient, "api/core/human_resource/behaviour")
        {
        }

        public async Task<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour>(_jsonOptions);
                    return result!;
                }
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BehaviourService.GetByEnvironmentIdAndId: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour>>(_jsonOptions);
                return result ?? new List<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BehaviourService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}