using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryMash.PactDemo.Provider.Model;

namespace BinaryMash.PactDemo.Server.Repositories
{
    public interface ISomethingRepository
    {
        IQueryable<Something> GetAll();
    }

    public class SomethingRepository : ISomethingRepository
    {
        
        private readonly List<Something> somethings = new List<Something>
        {
            new Something
            {
                Id = "tester",
                FirstName = "Totally",
                LastName = "Awesome"
            },
            new Something
            {
                Id = "abc",
                FirstName = "def",
                LastName = "ghi"
            }
        };

        public IQueryable<Something> GetAll()
        {
            return somethings.AsQueryable();
        }
    }
}
