using System.Net.Http.Json;

namespace Workforce.Services.Infra.WorkAgreement
{
    public class WorkAgreementService : CrudService<Domain.Infra.WorkAgreement.Entity.WorkAgreement>, IWorkAgreementService
    {
        public WorkAgreementService(HttpClient httpClient) : base(httpClient, "api/infra/workagreement")
        {
        }

        public async Task<Domain.Infra.WorkAgreement.Entity.WorkAgreement> GetByEnvironmentIdAndId(int environmentId, int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/environment/{environmentId}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Domain.Infra.WorkAgreement.Entity.WorkAgreement>(_jsonOptions);
                    return result!;
                }
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WorkAgreementService.GetByEnvironmentIdAndId: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<Domain.Infra.WorkAgreement.Entity.WorkAgreement>> GetAllByEnvironmentId(int environmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Infra.WorkAgreement.Entity.WorkAgreement>>(_jsonOptions);
                return result ?? new List<Domain.Infra.WorkAgreement.Entity.WorkAgreement>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WorkAgreementService.GetAllByEnvironmentId: {ex.Message}");
                throw;
            }
        }
    }
}