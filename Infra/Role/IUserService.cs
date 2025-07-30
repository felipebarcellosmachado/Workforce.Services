using Workforce.Domain.Infra.Role.Entity;

namespace Workforce.Services.Role
{
    public interface IUserService : ICrudService<User>
    {
        Task<User> LoginAsync(string username, string password);
    }
}