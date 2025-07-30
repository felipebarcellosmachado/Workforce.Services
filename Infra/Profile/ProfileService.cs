using System.Net.Http;
using Workforce.Domain.Admin.Profile.Entity;

namespace Workforce.Services.Infra.Profile
{
    public class ProfileService : CrudService<Workforce.Domain.Admin.Profile.Entity.Profile>, IProfileService
    {
        public ProfileService(HttpClient httpClient) : base(httpClient, "api/profile")
        {
        }
    }
}
