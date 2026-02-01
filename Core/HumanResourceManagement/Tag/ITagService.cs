using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workforce.Services.Core.HumanResourceManagement.Tag
{
    public interface ITagService
    {
        Task<Domain.Core.HumanResourceManagement.Tag.Entity.Tag?> GetByIdAsync(int id);
        Task<IList<Domain.Core.HumanResourceManagement.Tag.Entity.Tag>> GetAllByEnvironmentIdAsync(int environmentId);
        Task<Domain.Core.HumanResourceManagement.Tag.Entity.Tag> InsertAsync(object dto);
        Task<Domain.Core.HumanResourceManagement.Tag.Entity.Tag> UpdateAsync(int id, object dto);
        Task DeleteAsync(int id);
    }
}
