using Workforce.Domain.Infra.Role.Entity;

namespace Workforce.Services.Infra.Role.User
{
    public interface IUserService : ICrudService<Domain.Infra.Role.Entity.User>
    {
        Task<Domain.Infra.Role.Entity.User> LoginAsync(string username, string password);
    }
}