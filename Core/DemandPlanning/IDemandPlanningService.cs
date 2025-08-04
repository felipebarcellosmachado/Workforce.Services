using Workforce.Services;

namespace Workforce.Services.Core.DemandPlanning
{
    public interface IDemandPlanningService : ICrudService<Domain.Core.DemandPlanning.Entity.DemandPlanning>
    {
        Task<IList<Domain.Core.DemandPlanning.Entity.DemandPlanning>> GetAllByEnvironmentId(int environmentId);
    }
}