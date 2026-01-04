namespace Workforce.Services.Infra.Party
{
    /// <summary>
    /// Service interface for data script operations
    /// </summary>
    public interface IDataScriptsService
    {
        /// <summary>
        /// Executes the person insertion script
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Response with count of inserted persons</returns>
        Task<InsertPersonsResponse> InsertPersonsAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets the count of persons in the database
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Response with person count</returns>
        Task<CountPersonsResponse> CountPersonsAsync(CancellationToken ct = default);

        /// <summary>
        /// Executes the human resources insertion script
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Response with count of inserted human resources</returns>
        Task<InsertHumanResourcesResponse> InsertHumanResourcesAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets the count of human resources in the database
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Response with human resources count</returns>
        Task<CountHumanResourcesResponse> CountHumanResourcesAsync(CancellationToken ct = default);

        /// <summary>
        /// Executes the work units insertion script
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Response with count of inserted work units</returns>
        Task<InsertWorkUnitsResponse> InsertWorkUnitsAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets the count of work units in the database
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Response with work units count</returns>
        Task<CountWorkUnitsResponse> CountWorkUnitsAsync(CancellationToken ct = default);
    }

    /// <summary>
    /// Response for insert persons operation
    /// </summary>
    public class InsertPersonsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    /// <summary>
    /// Response for count persons operation
    /// </summary>
    public class CountPersonsResponse
    {
        public bool Success { get; set; }
        public int Persons { get; set; }
    }

    /// <summary>
    /// Response for insert human resources operation
    /// </summary>
    public class InsertHumanResourcesResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    /// <summary>
    /// Response for count human resources operation
    /// </summary>
    public class CountHumanResourcesResponse
    {
        public bool Success { get; set; }
        public int HumanResources { get; set; }
    }

    /// <summary>
    /// Response for insert work units operation
    /// </summary>
    public class InsertWorkUnitsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    /// <summary>
    /// Response for count work units operation
    /// </summary>
    public class CountWorkUnitsResponse
    {
        public bool Success { get; set; }
        public int WorkUnits { get; set; }
    }
}
