using System;
using Microsoft.Owin.Testing;
using PactNet;
using Xunit;

namespace BinaryMash.PactDemo.Provider.Tests
{
    public class CustomerApiTests
    {
        [Fact]
        public void EnsureCustomerApiHonoursPactWithConsumer()
        {
            IPactVerifier pactVerifier = new PactVerifier(SetUp(), TearDown());
            pactVerifier.ProviderState("There is a customer with ID tester", setUp: AddTesterIfItDoesntExist);
            pactVerifier.ProviderState("Version is 1.2.3.4", setUp: SetVersion);

            using (var testServer = TestServer.Create<Startup>())
            {
                pactVerifier = pactVerifier
                    .ServiceProvider("Customer API", testServer.HttpClient)
                    .HonoursPactWith("Consumer")
                    .PactUri("../../../BinaryMash.PactDemo.Consumer.Tests/pacts/consumer-customer_api.json");

                pactVerifier.Verify();
            }
        }


        private static Action TearDown()
        {
            return () => { };
        }

        private static Action SetUp()
        {
            return () => {};
        }

        private void AddTesterIfItDoesntExist()
        {
            //Logic to add the 'tester' customer
        }

        private void SetVersion()
        {
            //Logic to set the version
        }
    }
}
