using System.Net;
using System.Net.Http.Json;
using StaffingScheduleTypeEntity = Workforce.Domain.Core.StaffingScheduleManagement.StaffingScheduleType.Entity.StaffingScheduleType;

namespace Workforce.Services.Core.StaffingScheduleManagement.StaffingScheduleType;

public class StaffingScheduleTypeService : IStaffingScheduleTypeService
{
    private const string BaseUrl = "api/core/staffing-schedule-management/staffing-schedule-types";
    private readonly HttpClient httpClient;

    public StaffingScheduleTypeService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<StaffingScheduleTypeEntity?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        using var response = await httpClient.GetAsync($"{BaseUrl}/{id}", ct);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<StaffingScheduleTypeEntity>(cancellationToken: ct);
    }

    public Task<IList<StaffingScheduleTypeEntity>> GetAllAsync(CancellationToken ct = default)
    {
        return GetListAsync($"{BaseUrl}/all", ct);
    }

    public Task<IList<StaffingScheduleTypeEntity>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
    {
        return GetListAsync($"{BaseUrl}/all/environment/{environmentId}", ct);
    }

    public async Task<StaffingScheduleTypeEntity> InsertAsync(StaffingScheduleTypeEntity entity, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        using var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<StaffingScheduleTypeEntity>(cancellationToken: ct)
            ?? throw new InvalidOperationException("A API retornou uma entidade vazia.");
    }

    public async Task<StaffingScheduleTypeEntity?> UpdateAsync(StaffingScheduleTypeEntity entity, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        using var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<StaffingScheduleTypeEntity>(cancellationToken: ct);
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
    {
        using var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}", ct);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return false;
        }

        response.EnsureSuccessStatusCode();
        return true;
    }

    private async Task<IList<StaffingScheduleTypeEntity>> GetListAsync(string requestUri, CancellationToken ct)
    {
        using var response = await httpClient.GetAsync(requestUri, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IList<StaffingScheduleTypeEntity>>(cancellationToken: ct)
            ?? new List<StaffingScheduleTypeEntity>();
    }
}