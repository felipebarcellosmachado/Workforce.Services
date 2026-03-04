namespace Workforce.Services.Core.ProjectManagement.Program
{
    public interface IProgramService : ICrudService<Domain.Core.ProjectManagement.Program.Entity.Program>
    {
        Task<IList<Domain.Core.ProjectManagement.Program.Entity.Program>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    }
}
