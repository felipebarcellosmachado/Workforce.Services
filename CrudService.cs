using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net;

namespace Workforce.Services
{
    /// <summary>
    /// Simple CRUD service to handle API communications
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class CrudService<T> : ICrudService<T>
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUri;
        protected readonly JsonSerializerOptions _jsonOptions;
        
        /// <summary>
        /// Initializes a new instance of the CrudService class
        /// </summary>
        /// <param name="httpClient">HttpClient instance</param>
        /// <param name="baseUri">Base URL for API endpoints</param>
        public CrudService(HttpClient httpClient, string baseUri)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUri = baseUri?.TrimEnd('/') ?? throw new ArgumentNullException(nameof(baseUri));
            
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
        }
        
        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="dto">Data transfer object with entity information</param>
        /// <returns>Created entity</returns>
        public async Task<T> Insert(object dto)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(dto);
                
                Console.WriteLine($"CrudService.Insert: Making POST request to {_baseUri}");
                Console.WriteLine($"CrudService.Insert: HttpClient BaseAddress: {_httpClient.BaseAddress}");
                
                var response = await _httpClient.PostAsJsonAsync(_baseUri, dto, _jsonOptions);
                
                Console.WriteLine($"CrudService.Insert: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CrudService.Insert: Error response content: {errorContent}");
                    
                    // Log request details for debugging
                    var requestContent = await response.RequestMessage?.Content?.ReadAsStringAsync() ?? "null";
                    Console.WriteLine($"CrudService.Insert: Request content: {requestContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CrudService.Insert: {ex.Message}");
                Console.WriteLine($"Exception type: {ex.GetType().Name}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }
        
        /// <summary>
        /// Deletes an entity by its ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        public async Task Delete(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                
                var response = await _httpClient.DeleteAsync($"{_baseUri}/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CrudService.Delete: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Gets an entity by its ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Entity if found</returns>
        public async Task<T> GetById(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                
                var response = await _httpClient.GetAsync($"{_baseUri}/{id}");
                
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return default(T)!;
                    
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CrudService.GetById: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<IList<T>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<T>>(_jsonOptions);
                return result ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CrudService.GetAll: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Updates an existing entity
        /// </summary>
        /// <param name="dto">Data transfer object with updated entity information</param>
        /// <returns>Updated entity</returns>
        public async Task<T> Update(object dto)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(dto);
                
                // Get the ID from the dto
                var idProperty = dto.GetType().GetProperty("Id") 
                    ?? throw new ArgumentException("DTO must have an 'Id' property");
                    
                var id = idProperty.GetValue(dto) 
                    ?? throw new ArgumentException("DTO 'Id' property cannot be null");

                var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{id}", dto, _jsonOptions);
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CrudService.Update: {ex.Message}");
                throw;
            }
        }
    }
}
