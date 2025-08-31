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

        public async Task<IList<Organization>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Organization>>(_jsonOptions);
                return result ?? new List<Organization>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OrganizationService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }

        public async Task<Organization> GetByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name)) 
                    throw new ArgumentException("Name cannot be null or empty", nameof(name));

                Console.WriteLine($"OrganizationService.GetByName: Making GET request to {_baseUri}/name/{Uri.EscapeDataString(name)}");

                var response = await _httpClient.GetAsync($"{_baseUri}/name/{Uri.EscapeDataString(name)}");

                Console.WriteLine($"OrganizationService.GetByName: Response status: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"OrganizationService.GetByName: Organization with name '{name}' not found");
                    return null!;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"OrganizationService.GetByName: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Organization>(_jsonOptions);
                Console.WriteLine($"OrganizationService.GetByName: Successfully retrieved organization with name '{name}'");
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OrganizationService.GetByName: {ex.Message}");
                throw;
            }
        }

        public async Task<Organization> GetByEnvironmentIdAndName(int environmentId, string name)
        {
            try
            {
                if (environmentId <= 0) 
                    throw new ArgumentException("Environment ID must be greater than zero", nameof(environmentId));
                if (string.IsNullOrWhiteSpace(name)) 
                    throw new ArgumentException("Name cannot be null or empty", nameof(name));

                Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndName: Making GET request to {_baseUri}/environment/{environmentId}/name/{Uri.EscapeDataString(name)}");

                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/name/{Uri.EscapeDataString(name)}");

                Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndName: Response status: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndName: Organization with environment ID '{environmentId}' and name '{name}' not found");
                    return null!;
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndName: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Organization>(_jsonOptions);
                Console.WriteLine($"OrganizationService.GetByEnvironmentIdAndName: Successfully retrieved organization with environment ID '{environmentId}' and name '{name}'");
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OrganizationService.GetByEnvironmentIdAndName: {ex.Message}");
                throw;
            }
        }
    }
}
