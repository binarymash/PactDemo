using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace BinaryMash.PactDemo.Consumer.Tests
{
    public class ConsumerCustomerApiPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }

        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort
        {
            get { return 1234; }
        }

        public string MockProviderServiceBaseUri
        {
            get
            {
                return @"http://localhost:"+MockServerPort;
            }
        }

        public ConsumerCustomerApiPact()
        {
            PactBuilder = new PactBuilder()
                .ServiceConsumer("iOS")
                .HasPactWith("CustomerApi");

            ConfigureMockProvider();
        }

        private void ConfigureMockProvider()
        {
            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        public void Dispose()
        {
            PactBuilder.Build(); //NOTE: Will save the pact file once finished
        }
    }
}
