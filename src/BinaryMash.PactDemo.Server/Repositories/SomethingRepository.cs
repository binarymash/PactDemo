using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryMash.PactDemo.Model;

namespace BinaryMash.PactDemo.Server.Repositories
{
    public interface ISomethingRepository
    {
        IQueryable<Model.Something> GetAll();
    }

    public class SomethingRepository : ISomethingRepository
    {
        
        private readonly List<Model.Something> somethings = new List<Model.Something>
        {
            new Model.Something
            {
                Id = "tester",
                FirstName = "Totally",
                LastName = "Awesome"
            },
            new Model.Something
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
