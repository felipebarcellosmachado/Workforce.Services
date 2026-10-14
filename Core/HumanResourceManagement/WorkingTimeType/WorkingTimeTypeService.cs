using System.Net;
using System.Net.Http.Json;
using WorkingTimeTypeEntity = Workforce.Domain.Core.WorkManagement.WorkingTime.Entity.WorkingTimeType;

namespace Workforce.Services.Core.HumanResourceManagement.WorkingTimeType;

public class WorkingTimeTypeService : IWorkingTimeTypeService
{
    private const string BaseUrl = "api/core/work-management/working-time-types";
    private readonly HttpClient httpClient;

    public WorkingTimeTypeService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<WorkingTimeTypeEntity?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        using var response = await httpClient.GetAsync($"{BaseUrl}/{id}", ct);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<WorkingTimeTypeEntity>(cancellationToken: ct);
    }

    public async Task<IList<WorkingTimeTypeEntity>> GetAllAsync(CancellationToken ct = default)
    {
        return await GetListAsync($"{BaseUrl}/all", ct);
    }

    public async Task<IList<WorkingTimeTypeEntity>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
    {
        return await GetListAsync($"{BaseUrl}/all/environment/{environmentId}", ct);
    }

    public async Task<WorkingTimeTypeEntity> InsertAsync(WorkingTimeTypeEntity entity, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        using var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<WorkingTimeTypeEntity>(cancellationToken: ct)
            ?? throw new InvalidOperationException("A API retornou uma entidade vazia.");
    }

    public async Task<WorkingTimeTypeEntity?> UpdateAsync(WorkingTimeTypeEntity entity, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        using var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<WorkingTimeTypeEntity>(cancellationToken: ct);
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

    private async Task<IList<WorkingTimeTypeEntity>> GetListAsync(string requestUri, CancellationToken ct)
    {
        using var response = await httpClient.GetAsync(requestUri, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IList<WorkingTimeTypeEntity>>(cancellationToken: ct)
            ?? new List<WorkingTimeTypeEntity>();
    }
}
