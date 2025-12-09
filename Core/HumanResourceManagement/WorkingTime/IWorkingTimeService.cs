using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workforce.Services.Core.HumanResourceManagement.WorkingTime
{
    public interface IWorkingTimeService : ICrudService<Domain.Core.HumanResourceManagement.WorkingTime.Entity.WorkingTime>
    {
        Task<Domain.Core.HumanResourceManagement.WorkingTime.Entity.WorkingTime> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Core.HumanResourceManagement.WorkingTime.Entity.WorkingTime>> GetAllByEnvironmentId(int environmentId);
    }
}
