namespace Workforce.Services.Infra.Role.User
{
    public interface IUserService : ICrudService<Domain.Infra.Role.User.Entity.User>
    {
        Task<Domain.Infra.Role.User.Entity.User> LoginAsync(string username, string password);
    }
}