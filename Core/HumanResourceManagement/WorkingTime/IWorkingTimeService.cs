using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workforce.Services.Core.HumanResourceManagement.WorkingTime
{
    public interface IWorkingTimeService : ICrudService<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime>
    {
        Task<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Core.TourScheduleManagement.WorkingTime.Entity.WorkingTime>> GetAllByEnvironmentId(int environmentId);
    }
}
