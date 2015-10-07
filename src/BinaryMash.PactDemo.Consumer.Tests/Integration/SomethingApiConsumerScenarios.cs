using Xunit;
namespace BinaryMash.PactDemo.Consumer.Tests.Integration
{
    public class Temp
    {
        [Fact(Skip="Runn manually when the provider is running")]
        public void GetVersion()
        {
            var client = new CustomerApiConsumer("http://localhost:8080");
            var version = client.GetVersion();
            Assert.Equal("1.2.3.4", version.Build);
        }
    }
}
