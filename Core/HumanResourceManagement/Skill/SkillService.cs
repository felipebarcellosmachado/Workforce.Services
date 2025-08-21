using System.Net.Http.Json;
using Workforce.Services;

namespace Workforce.Services.Infra.HumanResource.Skill
{
    public class SkillService : CrudService<Domain.Core.HumanResourceManagement.Skill.Entity.Skill>, ISkillService
    {
        public SkillService(HttpClient httpClient) 
            : base(httpClient, "api/infra/humanresource/skill")
        {
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.Skill.Entity.Skill>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                Console.WriteLine($"SkillService.GetAllByEnvironmentId: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                
                Console.WriteLine($"SkillService.GetAllByEnvironmentId: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"SkillService.GetAllByEnvironmentId: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.Skill.Entity.Skill>>(_jsonOptions);
                var count = result?.Count ?? 0;
                Console.WriteLine($"SkillService.GetAllByEnvironmentId: Successfully retrieved {count} skills for environment {environmentId}");
                return result ?? new List<Domain.Core.HumanResourceManagement.Skill.Entity.Skill>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SkillService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}