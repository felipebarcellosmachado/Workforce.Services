using System.Net.Http.Json;
using Workforce.Domain.Infra.WorkingHour.Entity;

namespace Workforce.Services.Infra.WorkingHour
{
    public class WorkingHourService : CrudService<Domain.Infra.WorkingHour.Entity.WorkingHour>, IWorkingHourService
    {
        public WorkingHourService(HttpClient httpClient) : base(httpClient, "api/infra/workinghour")
        {
        }

        public async Task<Domain.Infra.WorkingHour.Entity.WorkingHour> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Domain.Infra.WorkingHour.Entity.WorkingHour>(_jsonOptions);
                    return result!;
                }
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WorkingHourService.GetByEnvironmentIdAndId: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Infra.WorkingHour.Entity.WorkingHour>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.WorkingHour.Entity.WorkingHour>>(_jsonOptions);
                return result ?? new List<Domain.Infra.WorkingHour.Entity.WorkingHour>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WorkingHourService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}