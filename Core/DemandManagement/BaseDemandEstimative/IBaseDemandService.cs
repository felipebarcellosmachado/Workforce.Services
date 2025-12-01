namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public interface IBaseDemandService : ICrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>
    {
        Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>> GetAllByBaseDemandEstimativeIdAsync(int baseDemandEstimativeId, CancellationToken ct = default);
        Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemand>> GetAllByBaseDemandPeriodIdAsync(int baseDemandPeriodId, CancellationToken ct = default);
    }
}
