using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Workforce.Services.Infra.Role.User
{
    public class UserService : CrudService<Domain.Infra.Role.User.Entity.User>, IUserService
    {
        public UserService(HttpClient httpClient) : base(httpClient, "api/infra/role/User")
        {
        }

        public async Task<Domain.Infra.Role.User.Entity.User> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUri}/login", new { username, password });
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Domain.Infra.Role.User.Entity.User>();
            }
            return null;
        }
    }
}