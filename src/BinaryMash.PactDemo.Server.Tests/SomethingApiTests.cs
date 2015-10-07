using System;
using Microsoft.Owin.Testing;
using PactNet;
using Xunit;

namespace BinaryMash.PactDemo.Server.Tests
{
    public class SomethingApiTests
    {
        [Fact]
        public void EnsureSomethingApiHonoursPactWithConsumer()
        {
            IPactVerifier pactVerifier = new PactVerifier(SetUp(), TearDown());
            pactVerifier.ProviderState("There is a something with ID tester", setUp: AddTesterIfItDoesntExist);
            pactVerifier.ProviderState("Version is 1.2.3.4", setUp: SetVersion);

            using (var testServer = TestServer.Create<Startup>())
            {
                pactVerifier = pactVerifier
                    .ServiceProvider("Something API", testServer.HttpClient)
                    .HonoursPactWith("Consumer")
                    .PactUri("../../../BinaryMash.PactDemo.Consumer.Tests/pacts/consumer-something_api.json");

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
            //Logic to add the 'tester' something
        }

        private void SetVersion()
        {
            //Logic to set the version
        }
    }
}
