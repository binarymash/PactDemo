using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using BinaryMash.PactDemo.Provider.Model;
using BinaryMash.PactDemo.Provider.Repositories;

namespace BinaryMash.PactDemo.Provider.Controllers
{

    public class SomethingsController : ApiController
    {
        public SomethingsController(ISomethingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Something Get(string id)
        {
            var something = _repository.GetAll().First(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (something == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return something;
        }

        private readonly ISomethingRepository _repository;
    }
}
