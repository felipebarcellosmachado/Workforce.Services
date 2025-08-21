namespace Workforce.Services.Core.DemandManagement.DemandEstimative
{
    public interface IDemandEstimativeService : ICrudService<Domain.Core.DemandManagement.DemandEstimative.Entity.DemandEstimative>
    {
        Task<IList<Domain.Core.DemandManagement.DemandEstimative.Entity.DemandEstimative>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    }
}