using System.Collections.Generic;
using System.Net;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;

namespace BinaryMash.PactDemo.Consumer.Tests.PactDefinitions
{
    public static class GetVersion
    {
        public static void CreateOn(IMockProviderService customerApi)
        {
            customerApi
                .Given("Version is 1.2.3.4")
                .UponReceiving("A GET request to retrieve the version")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path="/api/version",
                    Headers=new Dictionary<string, string>
                    {
                        {"Accept", "application/json"},
                        {"Another", "header" }
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
                    Body = new
                    {
                        Build="1.2.3.4",
                        Date="2015-09-17T20:29:13"
                    }
                });
        }
    }
}
