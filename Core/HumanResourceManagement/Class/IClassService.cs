using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workforce.Domain.Core.HumanResourceManagement.Class.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.Class
{
    public interface IClassService
    {
        Task<Domain.Core.HumanResourceManagement.Class.Entity.Class?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.Class.Entity.Class>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Domain.Core.HumanResourceManagement.Class.Entity.Class>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.Class.Entity.Class> InsertAsync(Domain.Core.HumanResourceManagement.Class.Entity.Class entity, CancellationToken ct = default);
        Task<Domain.Core.HumanResourceManagement.Class.Entity.Class?> UpdateAsync(Domain.Core.HumanResourceManagement.Class.Entity.Class entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
