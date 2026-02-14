using System.Net.Http.Json;
using System.Text.Json;
using Workforce.Domain.Core.StaffingScheduleManagement.BaseStaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.BaseStaffingSchedule
{
    public class BaseStaffingScheduleResourceService : CrudService<BaseStaffingScheduleResource>, IBaseStaffingScheduleResourceService
    {
        public BaseStaffingScheduleResourceService(HttpClient httpClient) : base(httpClient, "api/core/staffing-schedule-management/basestaffingscheduleresource")
        {
        }

        public async Task<IList<BaseStaffingScheduleResource>> GetAllByBaseStaffingScheduleIdAsync(int baseStaffingScheduleId, CancellationToken ct = default)
        {
            try
            {
                if (baseStaffingScheduleId <= 0)
                {
                    throw new ArgumentException("BaseStaffingSchedule ID deve ser maior que zero.", nameof(baseStaffingScheduleId));
                }

                var response = await _httpClient.GetAsync($"{_baseUri}/all/schedule/{baseStaffingScheduleId}", ct);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<BaseStaffingScheduleResource>>(_jsonOptions, ct);
                return result ?? new List<BaseStaffingScheduleResource>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingScheduleResourceService.GetAllByBaseStaffingScheduleIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<BaseStaffingScheduleResource>> InsertBatchAsync(IList<BaseStaffingScheduleResource> entities, CancellationToken ct = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entities);

                var response = await _httpClient.PostAsJsonAsync($"{_baseUri}/batch", entities, _jsonOptions, ct);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<BaseStaffingScheduleResource>>(_jsonOptions, ct);
                return result ?? new List<BaseStaffingScheduleResource>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingScheduleResourceService.InsertBatchAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAllByBaseStaffingScheduleIdAsync(int baseStaffingScheduleId, CancellationToken ct = default)
        {
            try
            {
                if (baseStaffingScheduleId <= 0)
                {
                    throw new ArgumentException("BaseStaffingSchedule ID deve ser maior que zero.", nameof(baseStaffingScheduleId));
                }

                var response = await _httpClient.DeleteAsync($"{_baseUri}/all/schedule/{baseStaffingScheduleId}", ct);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingScheduleResourceService.DeleteAllByBaseStaffingScheduleIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<BaseStaffingScheduleResource>> GenerateAsync(ResourceGenerationOptions options, CancellationToken ct = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(options);

                var response = await _httpClient.PostAsJsonAsync($"{_baseUri}/generate", options, _jsonOptions, ct);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<IList<BaseStaffingScheduleResource>>(_jsonOptions, ct);
                return result ?? new List<BaseStaffingScheduleResource>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BaseStaffingScheduleResourceService.GenerateAsync: {ex.Message}");
                throw;
            }
        }
    }
}
