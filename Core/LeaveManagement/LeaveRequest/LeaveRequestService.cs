using Workforce.Services;
using Workforce.Domain.Core.LeaveManagement.LeaveRequest.Entity;
using System.Net.Http.Json;
using Workforce.Domain.Core.LeaveManagement.LeaveRequest.Enum;

namespace Workforce.Services.Core.LeaveManagement.LeaveRequest
{
    public class LeaveRequestService : CrudService<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>, ILeaveRequestService
    {
        public LeaveRequestService(HttpClient httpClient) 
            : base(httpClient, "api/core/leave-management/leave-requests")
        {
        }

        public Task<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest> ApproveAsync(int id, CancellationToken ct = default) =>
            UpdateStatusAsync(id, "approve", ct);

        public Task<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest> RejectAsync(int id, CancellationToken ct = default) =>
            UpdateStatusAsync(id, "reject", ct);

        public Task<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest> CancelAsync(int id, CancellationToken ct = default) =>
            UpdateStatusAsync(id, "cancel", ct);

        public Task<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest> ReopenAsync(int id, CancellationToken ct = default) =>
            UpdateStatusAsync(id, "reopen", ct);

        private async Task<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest> UpdateStatusAsync(int id, string action, CancellationToken ct)
        {
            using var response = await _httpClient.PostAsync($"{_baseUri}/{id}/{action}", content: null, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>(_jsonOptions, ct)
                ?? throw new InvalidOperationException("A API retornou uma solicitação de licença vazia.");
        }

        public async Task<IList<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default)
        {
            try
            {
                Console.WriteLine($"LeaveRequestService.GetAllByEnvironmentIdAsync: Making GET request to {_baseUri}/all/environment/{environmentId}");
                
                var response = await _httpClient.GetAsync($"{_baseUri}/all/environment/{environmentId}", ct);
                
                Console.WriteLine($"LeaveRequestService.GetAllByEnvironmentIdAsync: Response status: {response.StatusCode}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync(ct);
                    Console.WriteLine($"LeaveRequestService.GetAllByEnvironmentIdAsync: Error response content: {errorContent}");
                }
                
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadFromJsonAsync<IList<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>>(_jsonOptions, ct);
                var count = result?.Count ?? 0;
                Console.WriteLine($"LeaveRequestService.GetAllByEnvironmentIdAsync: Successfully retrieved {count} entities for environment {environmentId}");
                return result ?? new List<Domain.Core.LeaveManagement.LeaveRequest.Entity.LeaveRequest>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LeaveRequestService.GetAllByEnvironmentIdAsync: {ex.Message}");
                throw;
            }
        }
    }
}