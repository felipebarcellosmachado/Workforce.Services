using Workforce.Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity;

namespace Workforce.Services.Core.StaffingScheduleManagement.StaffingSchedule
{
    public interface IStaffingScheduleService : ICrudService<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>
    {
        Task<IList<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule>> GetAllByEnvironmentIdAsync(int environmentId, CancellationToken ct = default);
        Task<Domain.Core.StaffingScheduleManagement.StaffingSchedule.Entity.StaffingSchedule?> GetByEnvironmentIdAndIdAsync(int environmentId, int id, CancellationToken ct = default);

        // Period
        Task<StaffingSchedulePeriod> InsertPeriodAsync(StaffingSchedulePeriod period, CancellationToken ct = default);
        Task<StaffingSchedulePeriod?> UpdatePeriodAsync(StaffingSchedulePeriod period, CancellationToken ct = default);
        Task DeletePeriodAsync(int id, CancellationToken ct = default);

        // Demand
        Task<StaffingScheduleDemand> InsertDemandAsync(StaffingScheduleDemand demand, CancellationToken ct = default);
        Task<StaffingScheduleDemand?> UpdateDemandAsync(StaffingScheduleDemand demand, CancellationToken ct = default);
        Task DeleteDemandAsync(int id, CancellationToken ct = default);

        // Resource
        Task<StaffingScheduleResource> InsertResourceAsync(StaffingScheduleResource resource, CancellationToken ct = default);
        Task<StaffingScheduleResource?> UpdateResourceAsync(StaffingScheduleResource resource, CancellationToken ct = default);
        Task DeleteResourceAsync(int id, CancellationToken ct = default);
        Task DeleteAllResourcesAsync(int staffingScheduleId, CancellationToken ct = default);
    }
}
