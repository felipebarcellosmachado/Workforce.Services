using System.Net.Http.Json;

namespace Workforce.Services.Core.HumanResourceManagement.WorkAgreement
{
    public class WorkAgreementService : CrudService<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>, IWorkAgreementService
    {
        public WorkAgreementService(HttpClient httpClient) : base(httpClient, "api/core/human_resource/WorkAgreement")
        {
        }

        public async Task<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                Console.WriteLine($"WorkAgreementService.GetByEnvironmentIdAndId: Requesting {_baseUri}/environment/{environmentId}/{id}");
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                
                Console.WriteLine($"WorkAgreementService.GetByEnvironmentIdAndId: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"WorkAgreementService.GetByEnvironmentIdAndId: Error response: {errorContent}");
                    return null!;
                }
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>(_jsonOptions);
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WorkAgreementService.GetByEnvironmentIdAndId: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return null!;
            }
        }

        public async Task<IList<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                Console.WriteLine($"WorkAgreementService.GetAllByEnvironmentId: Requesting {_baseUri}/all/environment/{environmentId}");
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                
                Console.WriteLine($"WorkAgreementService.GetAllByEnvironmentId: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"WorkAgreementService.GetAllByEnvironmentId: Error response: {errorContent}");
                    return new List<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>();
                }
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>>(_jsonOptions);
                Console.WriteLine($"WorkAgreementService.GetAllByEnvironmentId: Loaded {result?.Count ?? 0} items");
                return result ?? new List<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WorkAgreementService.GetAllByEnvironmentId: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return new List<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>();
            }
        }
    }
}