namespace Workforce.Services.Core.HumanResourceManagement.WorkAgreement
{
    public interface IWorkAgreementService : ICrudService<Domain.Core.HumanResourceManagement.WorkAgreement.Entity.WorkAgreement>
    {
        Task<Domain.Core.HumanResourceManagement.WorkAgreement.Entity.WorkAgreement> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Core.HumanResourceManagement.WorkAgreement.Entity.WorkAgreement>> GetAllByEnvironmentId(int environmentId);
    }
}