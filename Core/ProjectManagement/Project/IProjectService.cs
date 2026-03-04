namespace Workforce.Services.Core.ProjectManagement.Project
{
    public interface IProjectService : ICrudService<Domain.Core.ProjectManagement.Project.Entity.Project>
    {
        Task<IList<Domain.Core.ProjectManagement.Project.Entity.Project>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<IList<Domain.Core.ProjectManagement.Project.Entity.Project>> GetAllByProgramIdAsync(int programId, CancellationToken ct = default);
    }
}
