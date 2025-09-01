using System.Net.Http.Json;

namespace Workforce.Services.Core.HumanResourceManagement.JobTitle
{
    public class JobTitleService : CrudService<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>, IJobTitleService
    {
        public JobTitleService(HttpClient httpClient) : base(httpClient, "api/core/human_resource/jobtitle")
        {
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>>(_jsonOptions);
                return result ?? new List<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JobTitleService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}