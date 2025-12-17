using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Workforce.Services.Core.HumanResourceManagement.PairingManagement.PairingType
{
    public class PairingTypeService : IPairingTypeService
    {
        protected readonly HttpClient httpClient;
        protected readonly string baseUri;
        protected readonly System.Text.Json.JsonSerializerOptions jsonOptions;
        
        public PairingTypeService(HttpClient httpClient) 
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.baseUri = "api/core/pairing_management/pairing_type";
            
            this.jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = false,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>> GetAllAsync(CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"PairingTypeService.GetAllAsync: Making GET request to {baseUri}/all");
                
                var response = await httpClient.GetAsync($"{baseUri}/all", ct);
                
                Console.WriteLine($"PairingTypeService.GetAllAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"PairingTypeService.GetAllAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>>(jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"PairingTypeService.GetAllAsync: Successfully retrieved {count} pairing types");
                return result ?? new List<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingTypeService.GetAllAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"PairingTypeService.GetAllByEnvironmentIdAsync: Making GET request to {baseUri}/all/environment/{environmentId}");
                
                var response = await httpClient.GetAsync($"{baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"PairingTypeService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"PairingTypeService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>>(jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"PairingTypeService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} pairing types for environment {environmentId}");
                return result ?? new List<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingTypeService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                
                Console.WriteLine($"PairingTypeService.GetByIdAsync: Making GET request to {baseUri}/{id}");
                
                var response = await httpClient.GetAsync($"{baseUri}/{id}", ct);
                
                Console.WriteLine($"PairingTypeService.GetByIdAsync: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"PairingTypeService.GetByIdAsync: PairingType with ID {id} not found");
                    return null;
                }
                    
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>(jsonOptions, ct);
                Console.WriteLine($"PairingTypeService.GetByIdAsync: Successfully retrieved pairing type {id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingTypeService.GetByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType> InsertAsync(Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType entity, CancellationToken ct = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);

                Console.WriteLine($"PairingTypeService.InsertAsync: Preparing to send - Id={entity.Id}, EnvironmentId={entity.EnvironmentId}, Name={entity.Name}, Satisfability={entity.Satisfability}");
                Console.WriteLine($"PairingTypeService.InsertAsync: Making POST request to {baseUri}");
                
                var response = await httpClient.PostAsJsonAsync(baseUri, entity, jsonOptions, ct);
                
                Console.WriteLine($"PairingTypeService.InsertAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"PairingTypeService.InsertAsync: Error response content: {errorContent}");
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>(jsonOptions, ct);
                Console.WriteLine($"PairingTypeService.InsertAsync: Successfully created pairing type");
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingTypeService.InsertAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType?> UpdateAsync(Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType entity, CancellationToken ct = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);

                Console.WriteLine($"PairingTypeService.UpdateAsync: Making PUT request to {baseUri}/{entity.Id}");
                
                var response = await httpClient.PutAsJsonAsync($"{baseUri}/{entity.Id}", entity, jsonOptions, ct);
                
                Console.WriteLine($"PairingTypeService.UpdateAsync: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"PairingTypeService.UpdateAsync: PairingType with ID {entity.Id} not found");
                    return null;
                }
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"PairingTypeService.UpdateAsync: Error response content: {errorContent}");
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.PairingManagement.PairingType.Entity.PairingType>(jsonOptions, ct);
                Console.WriteLine($"PairingTypeService.UpdateAsync: Successfully updated pairing type {entity.Id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingTypeService.UpdateAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));

                Console.WriteLine($"PairingTypeService.DeleteByIdAsync: Making DELETE request to {baseUri}/{id}");
                
                var response = await httpClient.DeleteAsync($"{baseUri}/{id}", ct);
                
                Console.WriteLine($"PairingTypeService.DeleteByIdAsync: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"PairingTypeService.DeleteByIdAsync: PairingType with ID {id} not found");
                    return false;
                }

                response.EnsureSuccessStatusCode();
                Console.WriteLine($"PairingTypeService.DeleteByIdAsync: Successfully deleted pairing type {id}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PairingTypeService.DeleteByIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}
