using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;

namespace AutomaticTestingArmenianChairDogsitting.Clients
{
    public class AuthClient
    {
        private AuthClient _authClient;

        public AuthClient()
        {
            _authClient = new AuthClient();
        }

        public HttpContent Authorize(AuthRequestModel authModel, HttpStatusCode expectedCode)
        {
            string json = JsonSerializer.Serialize(authModel);

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Auth),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            return response.Content;
        }
    }
}
