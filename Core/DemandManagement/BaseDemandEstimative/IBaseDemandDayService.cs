namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public interface IBaseDemandDayService : ICrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandDay>
    {
        Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandDay>> GetAllByBaseDemandEstimativeIdAsync(int baseDemandEstimativeId, CancellationToken ct = default);
    }
}
