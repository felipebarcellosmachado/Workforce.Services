using System.Net.Http.Json;

namespace Workforce.Services.Infra.HumanResource.JobTitle
{
    public class JobTitleService : CrudService<Domain.Infra.HumanResource.JobTitle.Entity.JobTitle>, IJobTitleService
    {
        public JobTitleService(HttpClient httpClient) : base(httpClient, "api/infra/humanresource/jobtitle")
        {
        }

        public async Task<IList<Domain.Infra.HumanResource.JobTitle.Entity.JobTitle>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.HumanResource.JobTitle.Entity.JobTitle>>(_jsonOptions);
                return result ?? new List<Domain.Infra.HumanResource.JobTitle.Entity.JobTitle>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JobTitleService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}