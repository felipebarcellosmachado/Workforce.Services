using System.Net.Http.Json;

namespace Workforce.Services.Core.HumanResourceManagement.WorkingTime
{
    public class WorkingTimeService : CrudService<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime>, IWorkingTimeService
    {
        public WorkingTimeService(HttpClient httpClient) : base(httpClient, "api/core/human_resource/WorkingTime")
        {
        }

        public async Task<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime>(_jsonOptions);
                    return result!;
                }
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WorkingTimeService.GetByEnvironmentIdAndId: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime>>(_jsonOptions);
                return result ?? new List<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WorkingTimeService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}
