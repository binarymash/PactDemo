using Xunit;

namespace BinaryMash.PactDemo.Client.Tests.Integration
{
    public class Temp
    {
        [Fact]
        public void GetVersion()
        {
            var client = new SomethingApiClient("http://localhost:8080");
            var version = client.GetVersion();
            Assert.Equal("1.2.3.4", version.Build);
        }
    }
}
