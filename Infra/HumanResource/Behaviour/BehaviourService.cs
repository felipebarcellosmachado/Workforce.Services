using System.Net.Http.Json;
using Workforce.Domain.Infra.HumanResource.Behaviour.Entity;

namespace Workforce.Services.Infra.HumanResource.Behaviour
{
    public class BehaviourService : CrudService<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour>, IBehaviourService
    {
        public BehaviourService(HttpClient httpClient) : base(httpClient, "api/infra/humanresource/behaviour")
        {
        }

        public async Task<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour>(_jsonOptions);
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

        public async Task<IList<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour>>(_jsonOptions);
                return result ?? new List<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BehaviourService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}