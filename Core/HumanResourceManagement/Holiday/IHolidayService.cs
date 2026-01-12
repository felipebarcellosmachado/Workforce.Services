using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.HumanResourceManagement.Holiday.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.Holiday
{
    public interface IHolidayService
    {
        Task<Domain.Core.HumanResourceManagement.Holiday.Entity.Holiday?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.Holiday.Entity.Holiday>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.Holiday.Entity.Holiday>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.Holiday.Entity.Holiday> InsertAsync(Domain.Core.HumanResourceManagement.Holiday.Entity.Holiday entity, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.Holiday.Entity.Holiday?> UpdateAsync(Domain.Core.HumanResourceManagement.Holiday.Entity.Holiday entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
