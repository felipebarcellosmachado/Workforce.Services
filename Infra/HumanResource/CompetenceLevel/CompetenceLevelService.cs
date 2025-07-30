using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Workforce.Domain.Infra.HumanResource.CompetenceLevel.Entity;

namespace Workforce.Services.Infra.HumanResource.CompetenceLevel
{
    public class CompetenceLevelService : CrudService<Domain.Infra.HumanResource.CompetenceLevel.Entity.CompetenceLevel>, ICompetenceLevelService
    {
        public CompetenceLevelService(HttpClient httpClient) : base(httpClient, "api/infra/humanresource/competencelevel")
        {
        }

        public async Task<IList<Domain.Infra.HumanResource.CompetenceLevel.Entity.CompetenceLevel>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.HumanResource.CompetenceLevel.Entity.CompetenceLevel>>(_jsonOptions);
                return result ?? new List<Domain.Infra.HumanResource.CompetenceLevel.Entity.CompetenceLevel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CompetenceLevelService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}