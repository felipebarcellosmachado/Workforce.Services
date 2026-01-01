using Workforce.Domain.Admin.Session.Entity;
using Workforce.Realization.Infrastructure.Persistence.Admin.Session.Dto;

namespace Workforce.Services.Admin.Session
{
    /// <summary>
    /// Interface for Session service operations
    /// </summary>
    public interface ISessionService : ICrudService<Domain.Admin.Session.Entity.Session>
    {
        /// <summary>
        /// Get all sessions for a specific user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>List of sessions for the user</returns>
        Task<IList<Domain.Admin.Session.Entity.Session>> GetAllByUserId(int userId);

        /// <summary>
        /// Create a new login session
        /// </summary>
        /// <param name="loginRequest">Login request containing user and IP information</param>
        /// <returns>Created session</returns>
        Task<Domain.Admin.Session.Entity.Session> Login(LoginRequest loginRequest);

        /// <summary>
        /// Logout from a session
        /// </summary>
        /// <param name="sessionId">Session ID to logout</param>
        /// <returns>Updated session with logout time</returns>
        Task<Domain.Admin.Session.Entity.Session> Logout(int sessionId);

        /// <summary>
        /// Update session activity (heartbeat)
        /// </summary>
        /// <param name="sessionId">Session ID to update</param>
        /// <returns>Updated session with current activity time</returns>
        Task<Domain.Admin.Session.Entity.Session> HeartBeat(int sessionId);

        /// <summary>
        /// Get last N login sessions
        /// </summary>
        /// <param name="count">Number of recent logins to retrieve</param>
        /// <returns>List of recent login sessions</returns>
        Task<IList<Domain.Admin.Session.Entity.Session>> LastLogins(int count);

        /// <summary>
        /// Get sessions with activity within the last N seconds
        /// </summary>
        /// <param name="seconds">Number of seconds to look back for activity</param>
        /// <returns>List of recently active sessions</returns>
        Task<IList<Domain.Admin.Session.Entity.Session>> LastActivities(int seconds);
    }
}