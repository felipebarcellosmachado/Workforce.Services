using System.Net.Http.Json;
using Workforce.Services;

namespace Workforce.Services.Core.DemandPlanning
{
    public class DemandPlanningService : CrudService<Domain.Core.DemandPlanning.Entity.DemandPlanning>, IDemandPlanningService
    {
        public DemandPlanningService(HttpClient httpClient) : base(httpClient, "api/demandplanning")
        {
        }

        public async Task<IList<Domain.Core.DemandPlanning.Entity.DemandPlanning>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.DemandPlanning.Entity.DemandPlanning>>(_jsonOptions);
                return result ?? new List<Domain.Core.DemandPlanning.Entity.DemandPlanning>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DemandPlanningService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}