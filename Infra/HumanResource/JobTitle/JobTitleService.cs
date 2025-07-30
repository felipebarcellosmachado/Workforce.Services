using System.Net.Http;

namespace Workforce.Services.Infra.HumanResource.JobTitle
{
    public class JobTitleService : CrudService<Domain.Infra.HumanResource.JobTitle.Entity.JobTitle>, IJobTitleService
    {
        public JobTitleService(HttpClient httpClient) 
            : base(httpClient, "api/infra/humanresource/jobtitle")
        {
        }
    }
}