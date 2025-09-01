using System.Net.Http.Json;

namespace Workforce.Services.Core.HumanResourceManagement.Qualification
{
    public class QualificationService : CrudService<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification>, IQualificationService
    {
        public QualificationService(HttpClient httpClient) 
            : base(httpClient, "api/core/human_resource/qualification")
        {
        }

        public async Task<IList<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                Console.WriteLine($"QualificationService.GetAllByEnvironmentId: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                
                Console.WriteLine($"QualificationService.GetAllByEnvironmentId: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"QualificationService.GetAllByEnvironmentId: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification>>(_jsonOptions);
                var count = result?.Count ?? 0;
                Console.WriteLine($"QualificationService.GetAllByEnvironmentId: Successfully retrieved {count} qualifications for environment {environmentId}");
                return result ?? new List<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in QualificationService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }

        public async Task<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("ID must be greater than zero", nameof(id));
                if (environmentId <= 0) throw new ArgumentException("EnvironmentId must be greater than zero", nameof(environmentId));
                
                Console.WriteLine($"QualificationService.GetByEnvironmentIdAndId: Making GET request to {_baseUri}/environment/{environmentId}/{id}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                
                Console.WriteLine($"QualificationService.GetByEnvironmentIdAndId: Response status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"QualificationService.GetByEnvironmentIdAndId: Qualification with ID {id} not found for environment {environmentId}");
                    return default!;
                }
                    
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.HumanResourceManagement.Qualification.Entity.Qualification>(_jsonOptions);
                Console.WriteLine($"QualificationService.GetByEnvironmentIdAndId: Successfully retrieved qualification {id} for environment {environmentId}");
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in QualificationService.GetByEnvironmentIdAndId: {ex.Message}");
                throw;
            }
        }
    }
}