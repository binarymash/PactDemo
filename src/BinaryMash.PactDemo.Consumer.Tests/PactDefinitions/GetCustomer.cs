using System.Collections.Generic;
using System.Net;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;

namespace BinaryMash.PactDemo.Consumer.Tests.PactDefinitions
{
    public static class GetCustomer
    {
        public static void CreateOn(IMockProviderService customerApi)
        {
            customerApi
                .Given("There is a customer with ID tester")
                .UponReceiving("A GET request to retrieve the customer")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/customers/tester",
                    Headers = new Dictionary<string, string>
                    {
                        {"Accept", "application/json"},
                        {"Another", "header"}
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = (int)HttpStatusCode.OK,
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json; charset=utf-8" },
                        {"Another", "header"}
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
