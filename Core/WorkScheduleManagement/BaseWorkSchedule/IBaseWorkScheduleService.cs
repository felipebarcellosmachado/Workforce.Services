namespace Workforce.Services.Core.WorkScheduleManagement.BaseWorkSchedule
{
    public interface IBaseWorkScheduleService : ICrudService<Domain.Core.WorkScheduleManagement.BaseWorkSchedule.Entity.BaseWorkSchedule>
    {
        Task<IList<Domain.Core.WorkScheduleManagement.BaseWorkSchedule.Entity.BaseWorkSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
    }
}