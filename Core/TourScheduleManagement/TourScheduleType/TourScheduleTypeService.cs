using System.Net;
using System.Net.Http.Json;
using TourScheduleTypeEntity = Workforce.Domain.Core.TourScheduleManagement.TourScheduleType.Entity.TourScheduleType;

namespace Workforce.Services.Core.TourScheduleManagement.TourScheduleType;

public class TourScheduleTypeService : ITourScheduleTypeService
{
    private const string BaseUrl = "api/core/tour-schedule-management/tour-schedule-types";
    private readonly HttpClient httpClient;

    public TourScheduleTypeService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<TourScheduleTypeEntity?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        using var response = await httpClient.GetAsync($"{BaseUrl}/{id}", ct);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TourScheduleTypeEntity>(cancellationToken: ct);
    }

    public Task<IList<TourScheduleTypeEntity>> GetAllAsync(CancellationToken ct = default)
    {
        return GetListAsync($"{BaseUrl}/all", ct);
    }

    public Task<IList<TourScheduleTypeEntity>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
    {
        return GetListAsync($"{BaseUrl}/all/environment/{environmentId}", ct);
    }

    public async Task<TourScheduleTypeEntity> InsertAsync(TourScheduleTypeEntity entity, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        using var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TourScheduleTypeEntity>(cancellationToken: ct)
            ?? throw new InvalidOperationException("A API retornou uma entidade vazia.");
    }

    public async Task<TourScheduleTypeEntity?> UpdateAsync(TourScheduleTypeEntity entity, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        using var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TourScheduleTypeEntity>(cancellationToken: ct);
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

    private async Task<IList<TourScheduleTypeEntity>> GetListAsync(string requestUri, CancellationToken ct)
    {
        using var response = await httpClient.GetAsync(requestUri, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IList<TourScheduleTypeEntity>>(cancellationToken: ct)
            ?? new List<TourScheduleTypeEntity>();
    }
}