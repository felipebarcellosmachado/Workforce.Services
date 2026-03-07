using System.Net.Http.Json;
using System.Text.Json;

namespace Workforce.Services.Core.ProjectManagement.ActivityMode
{
    public class ActivityModeService : IActivityModeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri = "api/core/project-management/activity-mode";
        private readonly JsonSerializerOptions _jsonOptions;

        public ActivityModeService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = false,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };
        }

        public async Task<Domain.Core.ProjectManagement.Activity.Entity.ActivityMode> InsertAsync(
            Domain.Core.ProjectManagement.Activity.Entity.ActivityMode mode,
            CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(mode);

            var response = await _httpClient.PostAsJsonAsync(_baseUri, mode, _jsonOptions, ct);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Domain.Core.ProjectManagement.Activity.Entity.ActivityMode>(_jsonOptions, ct)
                ?? throw new InvalidOperationException("Server returned null after inserting ActivityMode.");
        }

        public async Task<Domain.Core.ProjectManagement.Activity.Entity.ActivityMode> UpdateAsync(
            Domain.Core.ProjectManagement.Activity.Entity.ActivityMode mode,
            CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(mode);

            var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{mode.Id}", mode, _jsonOptions, ct);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Domain.Core.ProjectManagement.Activity.Entity.ActivityMode>(_jsonOptions, ct)
                ?? throw new InvalidOperationException("Server returned null after updating ActivityMode.");
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUri}/{id}", ct);
            response.EnsureSuccessStatusCode();
        }
    }
}
