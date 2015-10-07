using System;
using System.Net;
using System.Net.Http;
using BinaryMash.PactDemo.Consumer.Model;
using Newtonsoft.Json;
using Version = BinaryMash.PactDemo.Consumer.Model.Version;

namespace BinaryMash.PactDemo.Consumer
{
    public class CustomerApiConsumer
    {
        public string BaseUri { get; set; }

        public CustomerApiConsumer(string baseUri = null)
        {
            BaseUri = baseUri ?? "http://my-api";
        }

        public Customer GetCustomer(string id)
        {
            string reasonPhrase;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(BaseUri) })
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/customers/" + id))
            {
                request.Headers.Add("Accept", "application/json");
                using (var response = httpClient.SendAsync(request))
                {

                    var content = response.Result.Content.ReadAsStringAsync().Result;
                    var status = response.Result.StatusCode;

                    reasonPhrase = response.Result.ReasonPhrase;

                    if (status == HttpStatusCode.OK)
                    {
                        return !string.IsNullOrEmpty(content)
                            ? JsonConvert.DeserializeObject<Customer>(content)
                            : null;
                    }
                }
            }

            throw new Exception(reasonPhrase);
        }

        public Version GetVersion()
        {
            string reasonPhrase;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(BaseUri) })
            //using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/version?abc=def"))
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/version"))
            {
                request.Headers.Add("Accept", "application/json");

                //MOD-3 - extra header sent by consumer
                //request.Headers.Add("PhilIsCool", "abc");

                using (var response = httpClient.SendAsync(request))
                {

                    var content = response.Result.Content.ReadAsStringAsync().Result;
                    var status = response.Result.StatusCode;

                    reasonPhrase = response.Result.ReasonPhrase;

                    if (status == HttpStatusCode.OK)
                    {
                        return !string.IsNullOrEmpty(content)
                            ? JsonConvert.DeserializeObject<Version>(content)
                            : null;
                    }
                }
            }

            throw new Exception(reasonPhrase);
        }
    }
}
