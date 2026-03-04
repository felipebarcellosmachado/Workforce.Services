using System.Net.Http.Json;

namespace Workforce.Services.Core.ProjectManagement.Project
{
    public class ProjectService : CrudService<Domain.Core.ProjectManagement.Project.Entity.Project>, IProjectService
    {
        public ProjectService(HttpClient httpClient) : base(httpClient, "api/core/project-management/project")
        {
        }

        public async Task<IList<Domain.Core.ProjectManagement.Project.Entity.Project>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<Domain.Core.ProjectManagement.Project.Entity.Project>>(_jsonOptions)
                   ?? new List<Domain.Core.ProjectManagement.Project.Entity.Project>();
        }

        public async Task<IList<Domain.Core.ProjectManagement.Project.Entity.Project>> GetAllByProgramIdAsync(int programId, CancellationToken ct = default)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/all/program/{programId}", ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<Domain.Core.ProjectManagement.Project.Entity.Project>>(_jsonOptions)
                   ?? new List<Domain.Core.ProjectManagement.Project.Entity.Project>();
        }
    }
}
