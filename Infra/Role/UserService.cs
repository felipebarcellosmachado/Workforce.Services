using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Workforce.Domain.Infra.Role.Entity;

namespace Workforce.Services.Role
{
    public class UserService : CrudService<User>, IUserService
    {
        public UserService(HttpClient httpClient) : base(httpClient, "api/infra/role/User")
        {
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUri}/login", new { username, password });
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }
    }
}