using System;
using Version = BinaryMash.PactDemo.Model.Version;

namespace BinaryMash.PactDemo.Server.Repositories
{
    public interface IVersionRepository
    {
        Version Get();
    }

    public class VersionRepository : IVersionRepository
    {
        public Version Get()
        {
            return new Version
            {
                Build = "1.2.3.4",
                Date = new DateTime(2015, 09, 17, 20, 29, 13),
                Branch = "Release"
            };
        }
    }
}
