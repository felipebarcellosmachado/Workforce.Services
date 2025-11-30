using System.Net.Http;
using System.Text.Json;
using System.Net;
using Workforce.Domain.Infra.Environment.Entity;
using System.Net.Http.Json;

namespace Workforce.Services.Infra.Environment
{
    public class EnvironmentService : CrudService<Domain.Infra.Environment.Entity.Environment>, IEnvironmentService
    {
        public EnvironmentService(HttpClient httpClient) : base(httpClient, "api/infra/Environment")
        {
        }

        public async Task<Domain.Infra.Environment.Entity.Environment> GetByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name)) 
                    throw new ArgumentException("Name cannot be null or empty", nameof(name));

                Console.WriteLine($"EnvironmentService.GetByName: Making GET request to {_baseUri}/name/{Uri.EscapeDataString(name)}");

                var response = await _httpClient.GetAsync($"{_baseUri}/name/{Uri.EscapeDataString(name)}");

                Console.WriteLine($"EnvironmentService.GetByName: Response status: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"EnvironmentService.GetByName: Environment with name '{name}' not found");
                    return null!;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"EnvironmentService.GetByName: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Domain.Infra.Environment.Entity.Environment>(_jsonOptions);
                Console.WriteLine($"EnvironmentService.GetByName: Successfully retrieved environment with name '{name}'");
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EnvironmentService.GetByName: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Infra.Environment.Entity.Environment>> GetAllByUserId(int userId)
        {
            try
            {
                if (userId <= 0)
                    throw new ArgumentException("UserId must be greater than zero", nameof(userId));

                Console.WriteLine($"EnvironmentService.GetAllByUserId: Making GET request to {_baseUri}/user/{userId}");

                var response = await _httpClient.GetAsync($"{_baseUri}/user/{userId}");

                Console.WriteLine($"EnvironmentService.GetAllByUserId: Response status: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"EnvironmentService.GetAllByUserId: No environments found for user with ID {userId}");
                    return new List<Domain.Infra.Environment.Entity.Environment>();
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"EnvironmentService.GetAllByUserId: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.Environment.Entity.Environment>>(_jsonOptions);
                Console.WriteLine($"EnvironmentService.GetAllByUserId: Successfully retrieved {result?.Count ?? 0} environments for user with ID {userId}");
                return result ?? new List<Domain.Infra.Environment.Entity.Environment>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EnvironmentService.GetAllByUserId: {ex.Message}");
                throw;
            }
        }
    }
}
