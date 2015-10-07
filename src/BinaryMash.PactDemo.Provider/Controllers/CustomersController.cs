using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using BinaryMash.PactDemo.Provider.Model;
using BinaryMash.PactDemo.Provider.Repositories;

namespace BinaryMash.PactDemo.Provider.Controllers
{

    public class CustomersController : ApiController
    {
        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Customer Get(string id)
        {
            var customer = _repository.GetAll().First(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        private readonly ICustomerRepository _repository;
    }
}
