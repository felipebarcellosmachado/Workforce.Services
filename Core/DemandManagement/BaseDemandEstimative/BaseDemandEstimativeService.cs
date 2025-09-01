using System.Text.Json;

namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public class BaseDemandEstimativeService : CrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>, IBaseDemandEstimativeService
    {
        public BaseDemandEstimativeService(HttpClient httpClient) : base(httpClient, "api/core/demand-management/base-demand-estimatives")
        {
        }

        public async Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            if (environmentId <= 0)
            {
                throw new ArgumentException("Environment ID deve ser maior que zero.", nameof(environmentId));
            }

            try
            {
                var requestUri = $"{_baseUri}/all/environment/{environmentId}";
                
                using var response = await _httpClient.GetAsync(requestUri, ct);
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    throw new HttpRequestException(
                        $"Falha na requisição para buscar estimativas base por ambiente. Status: {response.StatusCode}, Conteúdo: {errorContent}");
                }

                var json = await response.Content.ReadAsStringAsync(ct);
                
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>();
                }

                var result = JsonSerializer.Deserialize<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>>(json, _jsonOptions);
                
                return result ?? new List<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>();
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                throw;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Erro ao deserializar a resposta JSON das estimativas base de demanda.", ex);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro inesperado ao buscar estimativas base por ambiente ID {environmentId}.", ex);
            }
        }
    }
}