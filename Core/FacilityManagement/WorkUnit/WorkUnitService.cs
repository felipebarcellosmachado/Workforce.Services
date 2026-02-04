using System.Net.Http;
using System.Net.Http.Json;
using Workforce.Services.Infra;

namespace Workforce.Services.Core.FacilityManagement.WorkUnit
{
    public class WorkUnitService : CrudService<Workforce.Domain.Core.FacilityManagement.WorkUnit.Entity.WorkUnit>, IWorkUnitService
    {
        public WorkUnitService(HttpClient httpClient) : base(httpClient, "api/core/workunit")
        {
        }

        public async Task<IList<Workforce.Domain.Core.FacilityManagement.WorkUnit.Entity.WorkUnit>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IList<Workforce.Domain.Core.FacilityManagement.WorkUnit.Entity.WorkUnit>>() ?? new List<Workforce.Domain.Core.FacilityManagement.WorkUnit.Entity.WorkUnit>();
                }
                else
                {
                    throw new Exception($"Error fetching work units: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching work units: {ex.Message}", ex);
            }
        }
    }
}
