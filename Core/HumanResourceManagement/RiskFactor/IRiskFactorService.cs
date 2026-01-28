using Workforce.Domain.Core.HumanResourceManagement.RiskFactor.Entity;

namespace Workforce.Services.Core.HumanResourceManagement.RiskFactor
{
    public interface IRiskFactorService : ICrudService<Domain.Core.HumanResourceManagement.RiskFactor.Entity.RiskFactor>
    {
        Task<IList<Domain.Core.HumanResourceManagement.RiskFactor.Entity.RiskFactor>> GetAllByEnvironmentIdAsync(int environmentId);
    }
}
