using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Support;

namespace AutomaticTestingArmenianChairDogsitting.Clients
{
    public class CommentsClient
    {
        public void DeleteCommentById(int id, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new System.Uri($"{Urls.Сomments}/{id}"),
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);
        }
    }
}
