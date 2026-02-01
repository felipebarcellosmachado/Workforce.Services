using System.Net.Http.Json;
using Workforce.Services;

namespace Workforce.Services.Core.HumanResourceManagement.Tag
{
    public class TagService : CrudService<Domain.Core.HumanResourceManagement.Tag.Entity.Tag>, ITagService
    {
        public TagService(HttpClient httpClient) 
            : base(httpClient, "api/core/human_resource_management/tag")
        {
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.Tag.Entity.Tag>> GetAllByEnvironmentIdAsync(int environmentId)
        {
            try
            {
                Console.WriteLine($"TagService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                
                Console.WriteLine($"TagService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"TagService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.Tag.Entity.Tag>>(_jsonOptions);
                var count = result?.Count ?? 0;
                Console.WriteLine($"TagService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} tags for environment {environmentId}");
                return result ?? new List<Domain.Core.HumanResourceManagement.Tag.Entity.Tag>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TagService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.HumanResourceManagement.Tag.Entity.Tag?> GetByIdAsync(int id)
        {
            try
            {
                Console.WriteLine($"TagService.GetByIdAsync: Making GET request to {_baseUri}/{id}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/{id}");
                
                Console.WriteLine($"TagService.GetByIdAsync: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"TagService.GetByIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Tag.Entity.Tag>(_jsonOptions);
                Console.WriteLine($"TagService.GetByIdAsync: Successfully retrieved tag {id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TagService.GetByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.HumanResourceManagement.Tag.Entity.Tag> UpdateAsync(int id, object dto)
        {
            try
            {
                Console.WriteLine($"TagService.UpdateAsync: Making PUT request to {_baseUri}/{id}");
                
                var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{id}", dto, _jsonOptions);
                
                Console.WriteLine($"TagService.UpdateAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"TagService.UpdateAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Tag.Entity.Tag>(_jsonOptions);
                Console.WriteLine($"TagService.UpdateAsync: Successfully updated tag {id}");
                return result ?? throw new InvalidOperationException("Failed to deserialize updated tag");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TagService.UpdateAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                Console.WriteLine($"TagService.DeleteAsync: Making DELETE request to {_baseUri}/{id}");
                
                var response = await _httpClient.DeleteAsync($"{_baseUri}/{id}");
                
                Console.WriteLine($"TagService.DeleteAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"TagService.DeleteAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                Console.WriteLine($"TagService.DeleteAsync: Successfully deleted tag {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TagService.DeleteAsync: {ex.Message}");
                throw;
            }
        }
    }
}
