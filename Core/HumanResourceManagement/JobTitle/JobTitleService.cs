using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Workforce.Services.Core.HumanResourceManagement.JobTitle
{
    public class JobTitleService : CrudService<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>, IJobTitleService
    {
        public JobTitleService(HttpClient httpClient) : base(httpClient, "api/core/human_resource/JobTitle")
        {
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");

                Console.WriteLine($"CrudService.GetById: Response status: {response.StatusCode}");

                response.EnsureSuccessStatusCode();

                // Ler como string primeiro para evitar erros de memória com a desserialização direta
                var jsonString = await response.Content.ReadAsStringAsync();
                
                var result = JsonSerializer.Deserialize<IList<Domain.Core.HumanResourceManagement.JobTitle.Entity.JobTitle>>(jsonString, _jsonOptions);

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
