using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.WorkManagement.Holiday.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.Holiday
{
    public interface IHolidayService
    {
        Task<Domain.Core.WorkManagement.Holiday.Entity.Holiday?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.WorkManagement.Holiday.Entity.Holiday>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.WorkManagement.Holiday.Entity.Holiday>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.WorkManagement.Holiday.Entity.Holiday> InsertAsync(Domain.Core.WorkManagement.Holiday.Entity.Holiday entity, CancellationToken ct = default);
        Task<Domain.Core.WorkManagement.Holiday.Entity.Holiday?> UpdateAsync(Domain.Core.WorkManagement.Holiday.Entity.Holiday entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
