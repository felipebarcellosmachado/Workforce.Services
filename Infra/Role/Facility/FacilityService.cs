using System.Net.Http.Json;

namespace Workforce.Services.Infra.Role.Facility
{
    public class FacilityService : CrudService<Domain.Infra.Role.Facility.Entity.Facility>, IFacilityService
    {
        public FacilityService(HttpClient httpClient) : base(httpClient, "api/infra/role/facility")
        {
        }
        
        public async Task<IList<Domain.Infra.Role.Facility.Entity.Facility>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IList<Domain.Infra.Role.Facility.Entity.Facility>>() ?? new List<Domain.Infra.Role.Facility.Entity.Facility>();
                }
                else
                {
                    throw new Exception($"Error fetching facilities: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching facilities: {ex.Message}", ex);
            }
        }
    }
}