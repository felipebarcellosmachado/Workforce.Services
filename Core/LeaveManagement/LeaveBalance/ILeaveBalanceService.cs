using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.LeaveManagement.LeaveBalance.Entiyt;

namespace Workforce.Services.Core.LeaveManagement.LeaveBalance
{
    public interface ILeaveBalanceService
    {
        Task<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance> InsertAsync(Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance entity, CancellationToken ct = default);
        Task<Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance?> UpdateAsync(Domain.Core.LeaveManagement.LeaveBalance.Entiyt.LeaveBalance entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
