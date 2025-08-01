using System.Net.Http.Json;
using Workforce.Domain.Admin.Culture.Entity;

namespace Workforce.Services.Admin.Culture
{
    /// <summary>
    /// Service for Culture operations via HTTP API calls
    /// </summary>
    public class CultureEntityService : CrudService<Domain.Admin.Culture.Entity.Culture>, ICultureEntityService
    {
        public CultureEntityService(HttpClient httpClient) : base(httpClient, "api/admin/culture")
        {
        }

        /// <summary>
        /// Get culture by code
        /// </summary>
        /// <param name="code">Culture code (e.g., pt-BR)</param>
        /// <returns>Culture if found</returns>
        public async Task<Domain.Admin.Culture.Entity.Culture?> GetByCode(string code)
        {
            try
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(code);
                
                var response = await _httpClient.GetAsync($"{_baseUri}/code/{code}");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Admin.Culture.Entity.Culture>(_jsonOptions);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CultureEntityService.GetByCode: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get all active cultures
        /// </summary>
        /// <returns>List of active cultures</returns>
        public async Task<IList<Domain.Admin.Culture.Entity.Culture>> GetAllActive()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/active");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Admin.Culture.Entity.Culture>>(_jsonOptions);
                return result ?? new List<Domain.Admin.Culture.Entity.Culture>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CultureEntityService.GetAllActive: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get default culture
        /// </summary>
        /// <returns>Default culture</returns>
        public async Task<Domain.Admin.Culture.Entity.Culture?> GetDefault()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/default");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Admin.Culture.Entity.Culture>(_jsonOptions);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CultureEntityService.GetDefault: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Update culture resources (translations)
        /// </summary>
        /// <param name="id">Culture ID</param>
        /// <param name="resources">Dictionary of resource keys and values</param>
        /// <returns>Updated culture</returns>
        public async Task<Domain.Admin.Culture.Entity.Culture?> UpdateResources(int id, Dictionary<string, string> resources)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("Culture ID must be greater than zero", nameof(id));
                ArgumentNullException.ThrowIfNull(resources);
                
                var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{id}/resources", resources, _jsonOptions);
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Admin.Culture.Entity.Culture>(_jsonOptions);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CultureEntityService.UpdateResources: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get culture resources (translations)
        /// </summary>
        /// <param name="id">Culture ID</param>
        /// <returns>Dictionary of resource keys and values</returns>
        public async Task<Dictionary<string, string>?> GetResources(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("Culture ID must be greater than zero", nameof(id));
                
                var response = await _httpClient.GetAsync($"{_baseUri}/{id}/resources");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>(_jsonOptions);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CultureEntityService.GetResources: {ex.Message}");
                throw;
            }
        }
    }
}