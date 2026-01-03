using System.Net.Http.Json;

namespace Workforce.Services.Infra.Party
{
    /// <summary>
    /// Service for data script operations
    /// </summary>
    public class DataScriptsService : IDataScriptsService
    {
        private readonly HttpClient httpClient;
        private readonly string baseUri = "api/admin/datascripts";

        public DataScriptsService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Executes the person insertion script
        /// </summary>
        public async Task<InsertPersonsResponse> InsertPersonsAsync(CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"DataScriptsService.InsertPersons: Making POST request to {baseUri}/insert-persons");

                var response = await httpClient.PostAsync($"{baseUri}/insert-persons", null, ct);

                Console.WriteLine($"DataScriptsService.InsertPersons: Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"DataScriptsService.InsertPersons: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<InsertPersonsResponse>(ct);
                Console.WriteLine($"DataScriptsService.InsertPersons: Successfully inserted {result?.Count ?? 0} persons");
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataScriptsService.InsertPersons: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets the count of persons in the database
        /// </summary>
        public async Task<CountPersonsResponse> CountPersonsAsync(CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"DataScriptsService.CountPersons: Making GET request to {baseUri}/count-persons");

                var response = await httpClient.GetAsync($"{baseUri}/count-persons", ct);

                Console.WriteLine($"DataScriptsService.CountPersons: Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"DataScriptsService.CountPersons: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<CountPersonsResponse>(ct);
                Console.WriteLine($"DataScriptsService.CountPersons: Successfully retrieved count - {result?.Persons ?? 0} persons");
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataScriptsService.CountPersons: {ex.Message}");
                throw;
            }
        }
    }
}
