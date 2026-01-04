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

        /// <summary>
        /// Executes the human resources insertion script
        /// </summary>
        public async Task<InsertHumanResourcesResponse> InsertHumanResourcesAsync(CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"DataScriptsService.InsertHumanResources: Making POST request to {baseUri}/insert-humanresources");

                var response = await httpClient.PostAsync($"{baseUri}/insert-humanresources", null, ct);

                Console.WriteLine($"DataScriptsService.InsertHumanResources: Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"DataScriptsService.InsertHumanResources: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<InsertHumanResourcesResponse>(ct);
                Console.WriteLine($"DataScriptsService.InsertHumanResources: Successfully inserted {result?.Count ?? 0} human resources");
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataScriptsService.InsertHumanResources: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets the count of human resources in the database
        /// </summary>
        public async Task<CountHumanResourcesResponse> CountHumanResourcesAsync(CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"DataScriptsService.CountHumanResources: Making GET request to {baseUri}/count-humanresources");

                var response = await httpClient.GetAsync($"{baseUri}/count-humanresources", ct);

                Console.WriteLine($"DataScriptsService.CountHumanResources: Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"DataScriptsService.CountHumanResources: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<CountHumanResourcesResponse>(ct);
                Console.WriteLine($"DataScriptsService.CountHumanResources: Successfully retrieved count - {result?.HumanResources ?? 0} human resources");
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataScriptsService.CountHumanResources: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Executes the work units insertion script
        /// </summary>
        public async Task<InsertWorkUnitsResponse> InsertWorkUnitsAsync(CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"DataScriptsService.InsertWorkUnits: Making POST request to {baseUri}/insert-workunits");

                var response = await httpClient.PostAsync($"{baseUri}/insert-workunits", null, ct);

                Console.WriteLine($"DataScriptsService.InsertWorkUnits: Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"DataScriptsService.InsertWorkUnits: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<InsertWorkUnitsResponse>(ct);
                Console.WriteLine($"DataScriptsService.InsertWorkUnits: Successfully inserted {result?.Count ?? 0} work units");
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataScriptsService.InsertWorkUnits: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets the count of work units in the database
        /// </summary>
        public async Task<CountWorkUnitsResponse> CountWorkUnitsAsync(CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"DataScriptsService.CountWorkUnits: Making GET request to {baseUri}/count-workunits");

                var response = await httpClient.GetAsync($"{baseUri}/count-workunits", ct);

                Console.WriteLine($"DataScriptsService.CountWorkUnits: Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"DataScriptsService.CountWorkUnits: Error response content: {errorContent}");
                    throw new HttpRequestException($"HTTP Error ({(int)response.StatusCode}): {errorContent}", null, response.StatusCode);
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<CountWorkUnitsResponse>(ct);
                Console.WriteLine($"DataScriptsService.CountWorkUnits: Successfully retrieved count - {result?.WorkUnits ?? 0} work units");
                return result ?? throw new InvalidOperationException("Response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataScriptsService.CountWorkUnits: {ex.Message}");
                throw;
            }
        }
    }
}
