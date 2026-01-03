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
}
