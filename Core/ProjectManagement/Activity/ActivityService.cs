using System.Net.Http.Json;

namespace Workforce.Services.Core.ProjectManagement.Activity
{
    public class ActivityService : CrudService<Domain.Core.ProjectManagement.Activity.Entity.Activity>, IActivityService
    {
        public ActivityService(HttpClient httpClient) : base(httpClient, "api/core/project-management/activity")
        {
        }

        public async Task<IList<Domain.Core.ProjectManagement.Activity.Entity.Activity>> GetAllByProjectIdAsync(int projectId, CancellationToken ct = default)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/all/project/{projectId}", ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<Domain.Core.ProjectManagement.Activity.Entity.Activity>>(_jsonOptions)
                   ?? new List<Domain.Core.ProjectManagement.Activity.Entity.Activity>();
        }

        public async Task UpdatePredecessorsAsync(int activityId, IList<int> predecessorIds, CancellationToken ct = default)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{activityId}/predecessors", predecessorIds, _jsonOptions, ct);
            response.EnsureSuccessStatusCode();
        }
    }
}
