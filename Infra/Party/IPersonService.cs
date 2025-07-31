using Workforce.Domain.Infra.Party.Entity;
using Workforce.Services;

namespace Workforce.Services.Infra.Party
{
    public interface IPersonService : ICrudService<Person>
    {
        Task<IList<Person>> GetAllByEnvironmentId(int environmentId);
    }
}
