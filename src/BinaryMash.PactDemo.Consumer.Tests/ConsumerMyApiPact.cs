using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace BinaryMash.PactDemo.Consumer.Tests
{
    public class ConsumerMyApiPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }

        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort => 1234;

        public string MockProviderServiceBaseUri => $"http://localhost:{MockServerPort}";

        public ConsumerMyApiPact()
        {
            //PactBuilder = new PactBuilder(new PactConfig { PactDir = @"..\pacts", LogDir = @"c:\temp\logs" }); //Configures the PactDir and/or LogDir.

            PactBuilder = new PactBuilder()
                .ServiceConsumer("Consumer")
                .HasPactWith("Customer API");

            ConfigureMockProvider();
        }

        private void ConfigureMockProvider()
        {
            MockProviderService = PactBuilder.MockService(MockServerPort);

            //MockProviderService = PactBuilder.MockService(MockServerPort, true); //By passing true as the second param, you can enabled SSL. This will however require a valid SSL certificate installed and bound with netsh (netsh http add sslcert ipport=0.0.0.0:port certhash=thumbprint appid={app-guid}) on the machine running the test. See https://groups.google.com/forum/#!topic/nancy-web-framework/t75dKyfgzpg
            //                                                                     //or
            //MockProviderService = PactBuilder.MockService(MockServerPort, new JsonSerializerSettings()); //You can also change the default Json serialization settings using this overload

        }

        public void Dispose()
        {
            PactBuilder.Build(); //NOTE: Will save the pact file once finished
        }
    }
}
