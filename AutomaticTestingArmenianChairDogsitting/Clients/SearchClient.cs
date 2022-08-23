using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Support;
using System.Net.Http.Headers;

namespace AutomaticTestingArmenianChairDogsitting.Clients
{
    public class SearchClient
    {
        public HttpContent SearchSitters(SearchRequestModel model, string token, HttpStatusCode expectedCode)
        {
            string json = JsonSerializer.Serialize(model);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Search),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);
            return response.Content;
        }
    }
}
