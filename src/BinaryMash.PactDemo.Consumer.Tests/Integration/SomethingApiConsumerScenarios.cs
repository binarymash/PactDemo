using Xunit;
namespace BinaryMash.PactDemo.Consumer.Tests.Integration
{
    public class Temp
    {
        [Fact(Skip="Run manually when the provider is running")]
        //[Fact]
        public void GetVersion()
        {
            var client = new CustomerApiConsumer("http://localhost:8080");
            var version = client.GetVersion();
            Assert.Equal("1.2.3.4", version.Build);
        }

        [Fact(Skip="Run manually when the provider is running")]
        //[Fact]
        public void GetCustomer()
        {
            var client = new CustomerApiConsumer("http://localhost:8080");
            var customer = client.GetCustomer("tester");
            Assert.Equal("tester", customer.Id);
        }
    }
}
