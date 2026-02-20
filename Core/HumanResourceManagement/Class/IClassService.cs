using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.WorkManagement.Class.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.Class
{
    public interface IClassService
    {
        Task<Domain.Core.WorkManagement.Class.Entity.Class?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.WorkManagement.Class.Entity.Class>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.WorkManagement.Class.Entity.Class>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.WorkManagement.Class.Entity.Class> InsertAsync(Domain.Core.WorkManagement.Class.Entity.Class entity, CancellationToken ct = default);
        Task<Domain.Core.WorkManagement.Class.Entity.Class?> UpdateAsync(Domain.Core.WorkManagement.Class.Entity.Class entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
