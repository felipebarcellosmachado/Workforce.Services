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
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = false,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
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
                
                // Serialize the request content for logging
                var requestJson = JsonSerializer.Serialize(dto, _jsonOptions);
                Console.WriteLine($"CrudService.Insert: Request content: {requestJson}");
                
                var response = await _httpClient.PostAsJsonAsync(_baseUri, dto, _jsonOptions);
                
                Console.WriteLine($"CrudService.Insert: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CrudService.Insert: Error response content: {errorContent}");
                    
                    // Log request details for debugging
                    var requestContent = JsonSerializer.Serialize(dto, _jsonOptions);
                    Console.WriteLine($"CrudService.Insert: Request content: {requestContent}");
                    
                    // Throw specific exception with detailed error message
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new HttpRequestException($"Bad Request (400): {errorContent}", null, response.StatusCode);
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new HttpRequestException($"Unauthorized (401): {errorContent}", null, response.StatusCode);
                    }
                    else if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        throw new HttpRequestException($"Forbidden (403): {errorContent}", null, response.StatusCode);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new HttpRequestException($"Not Found (404): {errorContent}", null, response.StatusCode);
                    }
                    else if (response.StatusCode == HttpStatusCode.Conflict)
                    {
                        throw new HttpRequestException($"Conflict (409): {errorContent}", null, response.StatusCode);
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new HttpRequestException($"Internal Server Error (500): {errorContent}", null, response.StatusCode);
                    }
                    else
                    {
                        throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                    }
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
                Console.WriteLine($"CrudService.Insert: Successfully created entity");
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (HttpRequestException)
            {
                // Re-throw HttpRequestException as-is
                throw;
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                Console.WriteLine($"CrudService.Insert: Request timeout");
                throw new TimeoutException("The request timed out", ex);
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
                
                Console.WriteLine($"CrudService.Delete: Making DELETE request to {_baseUri}/{id}");
                
                var response = await _httpClient.DeleteAsync($"{_baseUri}/{id}");
                
                Console.WriteLine($"CrudService.Delete: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CrudService.Delete: Error response content: {errorContent}");
                    
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new HttpRequestException($"Entity with ID {id} not found", null, response.StatusCode);
                    }
                }
                
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"CrudService.Delete: Successfully deleted entity with ID {id}");
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
                
                Console.WriteLine($"CrudService.GetById: Making GET request to {_baseUri}/{id}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/{id}");
                
                Console.WriteLine($"CrudService.GetById: Response status: {response.StatusCode}");
                
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"CrudService.GetById: Entity with ID {id} not found");
                    return default(T)!;
                }
                    
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
                Console.WriteLine($"CrudService.GetById: Successfully retrieved entity with ID {id}");
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
                Console.WriteLine($"CrudService.GetAll: Making GET request to {_baseUri}/all");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all");
                
                Console.WriteLine($"CrudService.GetAll: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CrudService.GetAll: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<T>>(_jsonOptions);
                var count = result?.Count ?? 0;
                Console.WriteLine($"CrudService.GetAll: Successfully retrieved {count} entities");
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

                Console.WriteLine($"CrudService.Update: Making PUT request to {_baseUri}/{id}");
                Console.WriteLine($"CrudService.Update: Request data: {JsonSerializer.Serialize(dto, _jsonOptions)}");

                var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{id}", dto, _jsonOptions);
                
                Console.WriteLine($"CrudService.Update: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CrudService.Update: Error response content: {errorContent}");
                    
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new HttpRequestException($"Entity with ID {id} not found for update", null, response.StatusCode);
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new HttpRequestException($"Bad Request (400): {errorContent}", null, response.StatusCode);
                    }
                    else if (response.StatusCode == HttpStatusCode.Conflict)
                    {
                        throw new HttpRequestException($"Conflict (409): {errorContent}", null, response.StatusCode);
                    }
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
                Console.WriteLine($"CrudService.Update: Successfully updated entity with ID {id}");
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
