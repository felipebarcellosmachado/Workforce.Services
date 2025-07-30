using System.Net.Http;
using Workforce.Domain.Infra.Party.Entity;

namespace Workforce.Services.Infra.Party
{
    public class PersonService : CrudService<Person>, IPersonService
    {
        public PersonService(HttpClient httpClient) : base(httpClient, "api/infra/party/person")
        {
        }
    }
}
