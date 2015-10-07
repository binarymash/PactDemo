using System.Globalization;
using PactNet.Mocks.MockHttpService;
using Xunit;

namespace BinaryMash.PactDemo.Consumer.Tests
{
    public class CustomerApiConsumerTests : IClassFixture<ConsumerCustomerApiPact>
    {
        private readonly IMockProviderService mockProviderService;
        private readonly string mockProviderServiceBaseUri;

        public CustomerApiConsumerTests(ConsumerCustomerApiPact consumerMyApiPact)
        {
            this.mockProviderService = consumerMyApiPact.MockProviderService;
            this.mockProviderServiceBaseUri = consumerMyApiPact.MockProviderServiceBaseUri;
            this.mockProviderService.ClearInteractions();
        }

        [Fact]
        public void GettingCustomerThatExists()
        {
            //Given
            PactDefinitions.GetCustomer.CreateOn(this.mockProviderService);                
            var consumer = new CustomerApiConsumer(this.mockProviderServiceBaseUri);

            //When
            var result = consumer.GetCustomer("tester");

            //Then
            Assert.Equal("tester", result.Id);
            this.mockProviderService.VerifyInteractions(); //NOTE: Verifies that interactions registered on the mock provider are called once and only once
        }

        [Fact]
        public void GettingVersion()
        {
            //Given
            PactDefinitions.GetVersion.CreateOn(this.mockProviderService);
            var consumer = new CustomerApiConsumer(this.mockProviderServiceBaseUri);

            //When
            var result = consumer.GetVersion();
            
            //Then
            Assert.Equal("1.2.3.4", result.Build);
            Assert.Equal("09/17/2015 20:29:13", result.Date.ToString(CultureInfo.InvariantCulture));
            this.mockProviderService.VerifyInteractions(); //NOTE: Verifies that interactions registered on the mock provider are called once and only once
        }
    }
}
