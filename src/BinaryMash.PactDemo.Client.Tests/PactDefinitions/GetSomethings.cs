using System.Collections.Generic;
using System.Net;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;

namespace BinaryMash.PactDemo.Client.Tests.PactDefinitions
{
    public static class GetSomethings
    {
        public static void CreateOn(IMockProviderService somethingApi)
        {
            somethingApi
                .Given("There is a something with ID tester")
                .UponReceiving("A GET request to retrieve the something")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/somethings/tester",
                    Headers = new Dictionary<string, string>
                    {
                        {"Accept", "application/json" }
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = (int)HttpStatusCode.OK,
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new //NOTE: Note the case sensitivity here, the body will be serialised as per the casing defined
                    {
                        Id = "tester",
                        FirstName = "Totally",
                        LastName = "Awesome"
                    }
                }); //NOTE: WillRespondWith call must come last as it will register the interaction

        }
    }
}
