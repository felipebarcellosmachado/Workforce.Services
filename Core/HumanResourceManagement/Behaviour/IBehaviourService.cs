using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workforce.Services.Core.HumanResourceManagement.Behaviour
{
    public interface IBehaviourService : ICrudService<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour>
    {
        Task<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Core.HumanResourceManagement.Behaviour.Entity.Behaviour>> GetAllByEnvironmentId(int environmentId);
    }
}