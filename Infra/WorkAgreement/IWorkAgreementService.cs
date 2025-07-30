using Workforce.Domain.Infra.WorkAgreement.Entity;

namespace Workforce.Services.Infra.WorkAgreement
{
    public interface IWorkAgreementService : ICrudService<Domain.Infra.WorkAgreement.Entity.WorkAgreement>
    {
        Task<Domain.Infra.WorkAgreement.Entity.WorkAgreement> GetByEnvironmentIdAndId(int environmentId, int id);
        Task<IList<Domain.Infra.WorkAgreement.Entity.WorkAgreement>> GetAllByEnvironmentId(int environmentId);
    }
}