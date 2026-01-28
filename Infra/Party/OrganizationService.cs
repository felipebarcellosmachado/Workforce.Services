using System.Net.Http.Json;
using System.Net;
using Workforce.Domain.Infra.Party.Entity;

namespace Workforce.Services.Infra.Party
{
    public class OrganizationService : CrudService<Organization>, IOrganizationService
    {
        public OrganizationService(HttpClient httpClient) : base(httpClient, "api/infra/party/organization")
        {
        }

        public async Task<IList<Organization>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}", ct);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<Organization>>(_jsonOptions, ct);
                return result ?? new List<Organization>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OrganizationService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Organization> GetByNameAsync(string name, CancellationToken ct = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name)) 
                    throw new ArgumentException("Name cannot be null or empty", nameof(name));

                Console.WriteLine($"OrganizationService.GetByNameAsync: Making GET request to {_baseUri}/name/{Uri.EscapeDataString(name)}");

                var response = await _httpClient.GetAsync($"{_baseUri}/name/{Uri.EscapeDataString(name)}", ct);

                Console.WriteLine($"OrganizationService.GetByNameAsync: Response status: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"OrganizationService.GetByNameAsync: Organization with name '{name}' not found");
                    return null!;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"OrganizationService.GetByNameAsync: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Organization>(_jsonOptions, ct);
                Console.WriteLine($"OrganizationService.GetByNameAsync: Successfully retrieved organization with name '{name}'");
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OrganizationService.GetByNameAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Organization> GetByEnvironmentIdAndNameAsync(int environmentId, string name, CancellationToken ct = default)
        {
            try
            {
                if (environmentId <= 0) 
                    throw new ArgumentException("Environment ID must be greater than zero", nameof(environmentId));
                if (string.IsNullOrWhiteSpace(name)) 
                    throw new ArgumentException("Name cannot be null or empty", nameof(name));

                Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndNameAsync: Making GET request to {_baseUri}/environment/{environmentId}/name/{Uri.EscapeDataString(name)}");

                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/name/{Uri.EscapeDataString(name)}", ct);

                Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndNameAsync: Response status: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndNameAsync: Organization with environment ID '{environmentId}' and name '{name}' not found");
                    return null!;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndNameAsync: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Organization>(_jsonOptions, ct);
                Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndNameAsync: Successfully retrieved organization with environment ID '{environmentId}' and name '{name}'");
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OrganizationService.GetByEnvironmentIdAndNameAsync: {ex.Message}");
                throw;
            }
        }
    }
}
