using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.LeaveManagement.LeaveBalance.Entiyt;

namespace Workforce.Services.Core.LeaveManagement.LeaveBalance
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "api/core/leave-management/leave-balance";

        public LeaveBalanceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>($"{BaseUrl}/{id}", ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IList<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>> GetAllAsync(CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>>($"{BaseUrl}/all", ct) 
                ?? new List<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>();
        }

        public async Task<IList<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            return await httpClient.GetFromJsonAsync<IList<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>>($"{BaseUrl}/environment/{environmentId}", ct) 
                ?? new List<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>();
        }

        public async Task<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance> InsertAsync(Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance entity, CancellationToken ct = default)
        {
            var response = await httpClient.PostAsJsonAsync(BaseUrl, entity, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>(cancellationToken: ct)
                ?? throw new InvalidOperationException("Failed to deserialize response");
        }

        public async Task<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance?> UpdateAsync(Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance entity, CancellationToken ct = default)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}/{entity.Id}", entity, ct);
            if (response.StatusCode == HttpStatusCode.NotFound) return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>(cancellationToken: ct);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}", ct);
            if (response.StatusCode == HttpStatusCode.NotFound) return false;
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
