using System.Net.Http;
using System.Net.Http.Json;
using Workforce.Domain.Infra.Party.Entity;

namespace Workforce.Services.Infra.Party
{
    public class PersonService : CrudService<Person>, IPersonService
    {
        public PersonService(HttpClient httpClient) : base(httpClient, "api/infra/party/person")
        {
        }

        public async Task<IList<Person>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Person>>(_jsonOptions);
                return result ?? new List<Person>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PersonService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}
