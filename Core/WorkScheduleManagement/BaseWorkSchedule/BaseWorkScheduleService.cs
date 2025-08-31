using System.Text.Json;

namespace Workforce.Services.Core.WorkScheduleManagement.BaseWorkSchedule
{
    public class BaseWorkScheduleService : CrudService<Domain.Core.WorkScheduleManagement.BaseWorkSchedule.Entity.BaseWorkSchedule>, IBaseWorkScheduleService
    {
        public BaseWorkScheduleService(HttpClient httpClient) : base(httpClient, "api/core/work-schedule-management/base-work-schedules")
        {
        }

        public async Task<IList<Domain.Core.WorkScheduleManagement.BaseWorkSchedule.Entity.BaseWorkSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync(ct);
            var result = JsonSerializer.Deserialize<IList<Domain.Core.WorkScheduleManagement.BaseWorkSchedule.Entity.BaseWorkSchedule>>(json, _jsonOptions);
            
            return result ?? new List<Domain.Core.WorkScheduleManagement.BaseWorkSchedule.Entity.BaseWorkSchedule>();
        }
    }
}