using System.Net.Http;
using System.Net.Http.Json;
using System.Net;
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

        public async Task<Domain.Infra.Role.User.Entity.User> GetByLogin(string login)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login)) 
                    throw new ArgumentException("Login cannot be null or empty", nameof(login));

                Console.WriteLine($"UserService.GetByLogin: Making GET request to {_baseUri}/login/{Uri.EscapeDataString(login)}");

                var response = await _httpClient.GetAsync($"{_baseUri}/login/{Uri.EscapeDataString(login)}");

                Console.WriteLine($"UserService.GetByLogin: Response status: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"UserService.GetByLogin: User with login '{login}' not found");
                    return null!;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"UserService.GetByLogin: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Domain.Infra.Role.User.Entity.User>(_jsonOptions);
                Console.WriteLine($"UserService.GetByLogin: Successfully retrieved user with login '{login}'");
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserService.GetByLogin: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Infra.Role.User.Entity.User> GetByEnvironmentIdAndLogin(int environmentId, string login)
        {
            try
            {
                if (environmentId <= 0) 
                    throw new ArgumentException("Environment ID must be greater than zero", nameof(environmentId));
                if (string.IsNullOrWhiteSpace(login)) 
                    throw new ArgumentException("Login cannot be null or empty", nameof(login));

                Console.WriteLine($"UserService.GetByEnvironmentIdAndLogin: Making GET request to {_baseUri}/environment/{environmentId}/login/{Uri.EscapeDataString(login)}");

                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/login/{Uri.EscapeDataString(login)}");

                Console.WriteLine($"UserService.GetByEnvironmentIdAndLogin: Response status: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"UserService.GetByEnvironmentIdAndLogin: User with environment ID '{environmentId}' and login '{login}' not found");
                    return null!;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"UserService.GetByEnvironmentIdAndLogin: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Domain.Infra.Role.User.Entity.User>(_jsonOptions);
                Console.WriteLine($"UserService.GetByEnvironmentIdAndLogin: Successfully retrieved user with environment ID '{environmentId}' and login '{login}'");
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserService.GetByEnvironmentIdAndLogin: {ex.Message}");
                throw;
            }
        }
    }
}