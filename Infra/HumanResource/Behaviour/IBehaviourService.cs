using Workforce.Domain.Infra.HumanResource.Behaviour.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workforce.Services.Infra.HumanResource.Behaviour
{
    public interface IBehaviourService : ICrudService<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour>
    {
        Task<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Infra.HumanResource.Behaviour.Entity.Behaviour>> GetAllByEnvironmentId(int environmentId);
    }
}