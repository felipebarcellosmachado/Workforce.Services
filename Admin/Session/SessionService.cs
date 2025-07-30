using System.Net.Http;
using System.Net.Http.Json;
using Workforce.Domain.Admin.Session.Entity;
using Workforce.Business.Admin.Session.Dto;

namespace Workforce.Services.Admin.Session
{
    /// <summary>
    /// Service for Session operations via HTTP API calls
    /// </summary>
    public class SessionService : CrudService<Domain.Admin.Session.Entity.Session>, ISessionService
    {
        public SessionService(HttpClient httpClient) : base(httpClient, "api/admin/session/Session")
        {
        }

        /// <summary>
        /// Get all sessions for a specific user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>List of sessions for the user</returns>
        public async Task<IList<Domain.Admin.Session.Entity.Session>> GetAllByUserId(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}/user/{userId}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Admin.Session.Entity.Session>>(_jsonOptions);
                return result ?? new List<Domain.Admin.Session.Entity.Session>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SessionService.GetAllByUserId: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Create a new login session
        /// </summary>
        /// <param name="loginRequest">Login request containing user and IP information</param>
        /// <returns>Created session</returns>
        public async Task<Domain.Admin.Session.Entity.Session> Login(LoginRequest loginRequest)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(loginRequest);
                
                var response = await _httpClient.PostAsJsonAsync($"{_baseUri}/login", loginRequest, _jsonOptions);
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Admin.Session.Entity.Session>(_jsonOptions);
                return result ?? throw new InvalidOperationException("Login response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SessionService.Login: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Logout from a session
        /// </summary>
        /// <param name="sessionId">Session ID to logout</param>
        /// <returns>Updated session with logout time</returns>
        public async Task<Domain.Admin.Session.Entity.Session> Logout(int sessionId)
        {
            try
            {
                if (sessionId <= 0) throw new ArgumentException("Session ID must be greater than zero", nameof(sessionId));
                
                var response = await _httpClient.PostAsync($"{_baseUri}/logout/{sessionId}", null);
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Admin.Session.Entity.Session>(_jsonOptions);
                return result ?? throw new InvalidOperationException("Logout response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SessionService.Logout: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Update session activity (heartbeat)
        /// </summary>
        /// <param name="sessionId">Session ID to update</param>
        /// <returns>Updated session with current activity time</returns>
        public async Task<Domain.Admin.Session.Entity.Session> HeartBeat(int sessionId)
        {
            try
            {
                if (sessionId <= 0) throw new ArgumentException("Session ID must be greater than zero", nameof(sessionId));
                
                var response = await _httpClient.PostAsync($"{_baseUri}/heartbeat/{sessionId}", null);
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<Domain.Admin.Session.Entity.Session>(_jsonOptions);
                return result ?? throw new InvalidOperationException("HeartBeat response returned null");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SessionService.HeartBeat: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get last N login sessions
        /// </summary>
        /// <param name="count">Number of recent logins to retrieve</param>
        /// <returns>List of recent login sessions</returns>
        public async Task<IList<Domain.Admin.Session.Entity.Session>> LastLogins(int count)
        {
            try
            {
                if (count <= 0) throw new ArgumentException("Count must be greater than zero", nameof(count));
                
                var response = await _httpClient.GetAsync($"{_baseUri}/last-logins/{count}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Admin.Session.Entity.Session>>(_jsonOptions);
                return result ?? new List<Domain.Admin.Session.Entity.Session>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SessionService.LastLogins: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get sessions with activity within the last N seconds
        /// </summary>
        /// <param name="seconds">Number of seconds to look back for activity</param>
        /// <returns>List of recently active sessions</returns>
        public async Task<IList<Domain.Admin.Session.Entity.Session>> LastActivities(int seconds)
        {
            try
            {
                if (seconds <= 0) throw new ArgumentException("Seconds must be greater than zero", nameof(seconds));
                
                var response = await _httpClient.GetAsync($"{_baseUri}/last-activities/{seconds}");
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Admin.Session.Entity.Session>>(_jsonOptions);
                return result ?? new List<Domain.Admin.Session.Entity.Session>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SessionService.LastActivities: {ex.Message}");
                throw;
            }
        }
    }
}