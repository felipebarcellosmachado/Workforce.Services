namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public interface IBaseDemandEstimativeService : ICrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>
    {
        Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandEstimative>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    }
}