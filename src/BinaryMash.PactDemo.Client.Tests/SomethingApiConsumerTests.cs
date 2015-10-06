using System.Globalization;
using PactNet.Mocks.MockHttpService;
using Xunit;

namespace BinaryMash.PactDemo.Client.Tests
{
    public class SomethingApiConsumerTests : IClassFixture<ConsumerMyApiPact>
    {
        private readonly IMockProviderService mockProviderService;
        private readonly string mockProviderServiceBaseUri;

        public SomethingApiConsumerTests(ConsumerMyApiPact consumerMyApiPact)
        {
            this.mockProviderService = consumerMyApiPact.MockProviderService;
            this.mockProviderServiceBaseUri = consumerMyApiPact.MockProviderServiceBaseUri;
            this.mockProviderService.ClearInteractions();
        }

        [Fact]
        public void GettingSomethingThatExists()
        {
            //Given
            PactDefinitions.GetSomethings.CreateOn(this.mockProviderService);                
            var consumer = new SomethingApiClient(this.mockProviderServiceBaseUri);

            //When
            var result = consumer.GetSomething("tester");

            //Then
            Assert.Equal("tester", result.Id);
            this.mockProviderService.VerifyInteractions(); //NOTE: Verifies that interactions registered on the mock provider are called once and only once
        }

        [Fact]
        public void GettingVersion()
        {
            //Given
            PactDefinitions.GetVersion.CreateOn(this.mockProviderService);
            var consumer = new SomethingApiClient(this.mockProviderServiceBaseUri);

            //When
            var result = consumer.GetVersion();
            
            //Then
            Assert.Equal("1.2.3.4", result.Build);
            Assert.Equal("09/17/2015 20:29:13", result.Date.ToString(CultureInfo.InvariantCulture));
            this.mockProviderService.VerifyInteractions(); //NOTE: Verifies that interactions registered on the mock provider are called once and only once
        }
    }
}
