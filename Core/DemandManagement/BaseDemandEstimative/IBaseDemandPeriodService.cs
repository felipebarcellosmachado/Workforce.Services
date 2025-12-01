namespace Workforce.Services.Core.DemandManagement.BaseDemandEstimative
{
    public interface IBaseDemandPeriodService : ICrudService<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandPeriod>
    {
        Task<IList<Domain.Core.DemandManagement.BaseDemandEstimative.Entity.BaseDemandPeriod>> GetAllByBaseDemandDayIdAsync(int baseDemandDayId, CancellationToken ct = default);
    }
}
