using System.Net.Http.Json;

namespace Workforce.Services.Core.ProjectManagement.Program
{
    public class ProgramService : CrudService<Domain.Core.ProjectManagement.Program.Entity.Program>, IProgramService
    {
        public ProgramService(HttpClient httpClient) : base(httpClient, "api/core/project-management/program")
        {
        }

        public async Task<IList<Domain.Core.ProjectManagement.Program.Entity.Program>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<Domain.Core.ProjectManagement.Program.Entity.Program>>(_jsonOptions)
                   ?? new List<Domain.Core.ProjectManagement.Program.Entity.Program>();
        }
    }
}
