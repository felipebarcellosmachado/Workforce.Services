namespace Workforce.Services.Core.HumanResourceManagement.WorkAgreement
{
    public interface IWorkAgreementService : ICrudService<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>
    {
        Task<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Core.WorkManagement.WorkAgreement.Entity.WorkAgreement>> GetAllByEnvironmentId(int environmentId);
    }
}