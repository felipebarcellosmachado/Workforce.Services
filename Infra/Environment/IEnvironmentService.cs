using Workforce.Domain.Infra.Environment.Entity;
using Workforce.Services;

namespace Workforce.Services.Infra.Environment
{
    public interface IEnvironmentService : ICrudService<Domain.Infra.Environment.Entity.Environment>
    {
        Task<Domain.Infra.Environment.Entity.Environment> GetByName(string name);
    }
}
