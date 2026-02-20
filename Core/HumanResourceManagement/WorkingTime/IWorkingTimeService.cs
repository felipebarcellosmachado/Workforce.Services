using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workforce.Services.Core.HumanResourceManagement.WorkingTime
{
    public interface IWorkingTimeService : ICrudService<Domain.Core.WorkManagement.WorkingTime.Entity.WorkingTime>
    {
        Task<Domain.Core.WorkManagement.WorkingTime.Entity.WorkingTime> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Core.WorkManagement.WorkingTime.Entity.WorkingTime>> GetAllByEnvironmentId(int environmentId);
    }
}
