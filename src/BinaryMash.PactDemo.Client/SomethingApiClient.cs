using System;
using System.Net;
using System.Net.Http;
using BinaryMash.PactDemo.Model;
using Newtonsoft.Json;

namespace BinaryMash.PactDemo.Client
{
    public class SomethingApiClient
    {
        public string BaseUri { get; set; }

        public SomethingApiClient(string baseUri = null)
        {
            BaseUri = baseUri ?? "http://my-api";
        }

        public Something GetSomething(string id)
        {
            string reasonPhrase;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(BaseUri) })
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/somethings/" + id))
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
                            ? JsonConvert.DeserializeObject<Something>(content)
                            : null;
                    }
                }
            }

            throw new Exception(reasonPhrase);
        }

        public Model.Version GetVersion()
        {
            string reasonPhrase;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(BaseUri) })
            //using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/version?abc=def"))
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/version"))
            {
                request.Headers.Add("Accept", "application/json");
                //request.Headers.Add("PhilIsCool", "abc");

                using (var response = httpClient.SendAsync(request))
                {

                    var content = response.Result.Content.ReadAsStringAsync().Result;
                    var status = response.Result.StatusCode;

                    reasonPhrase = response.Result.ReasonPhrase;

                    if (status == HttpStatusCode.OK)
                    {
                        return !string.IsNullOrEmpty(content)
                            ? JsonConvert.DeserializeObject<Model.Version>(content)
                            : null;
                    }
                }
            }

            throw new Exception(reasonPhrase);
        }
    }
}
