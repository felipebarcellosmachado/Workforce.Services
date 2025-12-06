using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workforce.Services.Core.HumanResourceManagement.WorkingTime
{
    public interface IWorkingTimeService : ICrudService<Domain.Core.HumanResourceManagement.WorkingHour.Entity.WorkingTime>
    {
        Task<Domain.Core.HumanResourceManagement.WorkingHour.Entity.WorkingTime> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Core.HumanResourceManagement.WorkingHour.Entity.WorkingTime>> GetAllByEnvironmentId(int environmentId);
    }
}
