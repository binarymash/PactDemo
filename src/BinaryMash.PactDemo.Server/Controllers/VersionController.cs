using System;
using System.Web.Http;
using BinaryMash.PactDemo.Server.Repositories;
using Version = BinaryMash.PactDemo.Model.Version;

namespace BinaryMash.PactDemo.Server.Controllers
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
