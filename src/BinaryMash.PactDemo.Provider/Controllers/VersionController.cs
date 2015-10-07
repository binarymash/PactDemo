using System.Web.Http;
using BinaryMash.PactDemo.Provider.Repositories;
using Version = BinaryMash.PactDemo.Provider.Model.Version;

namespace BinaryMash.PactDemo.Provider.Controllers
{
    public class VersionController : ApiController
    {
        private readonly IVersionRepository _repository;

        public VersionController(IVersionRepository versionRepository)
        {
            _repository = versionRepository;
        }

        public Version Get()
        {
            return _repository.Get();
        }
    }
}
