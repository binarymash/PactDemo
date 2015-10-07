using System.Collections.Generic;
using System.Linq;
using BinaryMash.PactDemo.Provider.Model;

namespace BinaryMash.PactDemo.Provider.Repositories
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAll();
    }

    public class CustomerRepository : ICustomerRepository
    {
        
        private readonly List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Id = "tester",
                FirstName = "Totally",
                LastName = "Awesome"
            },
            new Customer
            {
                Id = "abc",
                FirstName = "def",
                LastName = "ghi"
            }
        };

        public IQueryable<Customer> GetAll()
        {
            return customers.AsQueryable();
        }
    }
}
