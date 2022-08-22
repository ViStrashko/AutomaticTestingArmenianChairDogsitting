using AutomaticTestingArmenianChairDogsitting.Clients;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class AdminSteps
    {
        private ClientsClient _clientsClient;
        private SittersClient _sittersClient;
        private OrdersClient _ordersClient;
        private CommentsClient _commentsClient;

        public AdminSteps()
        {
            _clientsClient = new ClientsClient();
            _sittersClient = new SittersClient();
            _ordersClient = new OrdersClient();
            _commentsClient = new CommentsClient();
        }

        public void DeleteClientByAdminTest(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _clientsClient.DeleteClientByAdmin(id, token, expectedDeleteCode);
        }

        public void DeleteSitterByAdminTest(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _sittersClient.DeleteSitterByAdmin(id, token, expectedDeleteCode);
        }

        public void RestoringClientProfileByClientIdTest(int id, string token)
        {
            HttpStatusCode expectedRestoringCode = HttpStatusCode.NoContent;
            _clientsClient.RestoringClientProfileByClientById(id, token, expectedRestoringCode);
        }

        public List<ClientsGetAllResponseModel> FindAddedClientProfileInListTest(string token, ClientsGetAllResponseModel expectedClient)
        {
            HttpContent content = _clientsClient.GetAllClients(token, HttpStatusCode.OK);
            List<ClientsGetAllResponseModel> actualClients = JsonSerializer.Deserialize<List<ClientsGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.Contains(actualClients, expectedClient);
            return actualClients;
        }

        public List<ClientsGetAllResponseModel> FindDeletedClientProfileInListTest(string token, ClientsGetAllResponseModel expectedClient)
        {
            HttpContent content = _clientsClient.GetAllClients(token, HttpStatusCode.OK);
            List<ClientsGetAllResponseModel> actualClients = JsonSerializer.Deserialize<List<ClientsGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.DoesNotContain(actualClients, expectedClient);
            return actualClients;
        }

        public void RestoreSittersProfileBySitterIdTest(int id, string adminToken)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;
            _sittersClient.RestoreSitterProfileBySitterId(id, adminToken, expectedCode);
        }

        public List<SittersGetAllResponseModel> FindAddedSitterProfileInListTest(string token, SittersGetAllResponseModel expectedSitter)
        {
            HttpContent content = _sittersClient.GetAllSitters(token, HttpStatusCode.OK);
            List<SittersGetAllResponseModel> actualSiterrs = JsonSerializer.Deserialize<List<SittersGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.Contains(actualSiterrs, expectedSitter);
            return actualSiterrs;
        }

        public List<SittersGetAllResponseModel> FindDeletedSitterProfileInListTest(string token, SittersGetAllResponseModel expectedSitter)
        {
            HttpContent content = _sittersClient.GetAllSitters(token, HttpStatusCode.OK);
            List<SittersGetAllResponseModel> actualSiterrs = JsonSerializer.Deserialize<List<SittersGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.DoesNotContain(actualSiterrs, expectedSitter);
            return actualSiterrs;
        }

        public List<CommentAllInfoResponseModel> FindAddedCommentByOrderIdTest(int id, string token, CommentAllInfoResponseModel expectedComment)
        {
            HttpContent content = _ordersClient.GetAllInfoCommentsByOrderId(id, token, HttpStatusCode.OK);
            List<CommentAllInfoResponseModel> actualComments = JsonSerializer.Deserialize<List<CommentAllInfoResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.Contains(actualComments, expectedComment);
            return actualComments;
        }

        public List<CommentAllInfoResponseModel> FindDeletedCommentByOrderIdTest(int id, string token, CommentAllInfoResponseModel expectedComment)
        {
            HttpContent content = _ordersClient.GetAllInfoCommentsByOrderId(id, token, HttpStatusCode.OK);
            List<CommentAllInfoResponseModel> actualComments = JsonSerializer.Deserialize<List<CommentAllInfoResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.DoesNotContain(actualComments, expectedComment);
            return actualComments;
        }

        public List<CommentAllInfoResponseModel> ViewCommentByOrderIdTest(int id, string token, List<CommentAllInfoResponseModel> expectedComments)
        {
            HttpContent content = _ordersClient.GetAllInfoCommentsByOrderId(id, token, HttpStatusCode.OK);
            List<CommentAllInfoResponseModel> actualComments = JsonSerializer.Deserialize<List<CommentAllInfoResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.AreEquivalent(actualComments, expectedComments);
            return actualComments;
        }

        public void DeleteCommentByIdTest(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _commentsClient.DeleteCommentById(id, token, expectedDeleteCode);
        }
    }
}
