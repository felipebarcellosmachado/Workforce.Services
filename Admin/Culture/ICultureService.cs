using Workforce.Domain.Admin.Culture.Entity;

namespace Workforce.Services.Admin.Culture
{
    /// <summary>
    /// Interface for Culture entity operations via HTTP API calls
    /// </summary>
    public interface ICultureEntityService : ICrudService<Domain.Admin.Culture.Entity.Culture>
    {
        /// <summary>
        /// Get culture by code
        /// </summary>
        /// <param name="code">Culture code (e.g., pt-BR)</param>
        /// <returns>Culture if found</returns>
        Task<Domain.Admin.Culture.Entity.Culture?> GetByCode(string code);

        /// <summary>
        /// Get all active cultures
        /// </summary>
        /// <returns>List of active cultures</returns>
        Task<IList<Domain.Admin.Culture.Entity.Culture>> GetAllActive();

        /// <summary>
        /// Get default culture
        /// </summary>
        /// <returns>Default culture</returns>
        Task<Domain.Admin.Culture.Entity.Culture?> GetDefault();

        /// <summary>
        /// Update culture resources (translations)
        /// </summary>
        /// <param name="id">Culture ID</param>
        /// <param name="resources">Dictionary of resource keys and values</param>
        /// <returns>Updated culture</returns>
        Task<Domain.Admin.Culture.Entity.Culture?> UpdateResources(int id, Dictionary<string, string> resources);

        /// <summary>
        /// Get culture resources (translations)
        /// </summary>
        /// <param name="id">Culture ID</param>
        /// <returns>Dictionary of resource keys and values</returns>
        Task<Dictionary<string, string>?> GetResources(int id);
    }
}