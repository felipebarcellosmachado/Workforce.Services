using Entity = Workforce.Domain.Core.ContextManagement.Context.Entity;

namespace Workforce.Services.Core.ContextManagement.Context
{
    public interface IContextService
    {
        Task<Entity.Context?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IList<Entity.Context>> GetAllAsync(CancellationToken ct = default);
        Task<IList<Entity.Context>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Entity.Context?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);
        Task<Entity.Context> InsertAsync(Entity.Context entity, CancellationToken ct = default);
        Task<Entity.Context?> UpdateAsync(Entity.Context entity, CancellationToken ct = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);
    }
}
