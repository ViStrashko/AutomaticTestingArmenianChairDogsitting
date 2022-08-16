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
        private AdminsClient _adminsClient;
        private ClientsClient _clientsClient;
        private SittersClient _sittersClient;


        public AdminSteps()
        {
            _adminsClient = new AdminsClient();
            _clientsClient = new ClientsClient();
            _sittersClient = new SittersClient();
        }

        public void RestoringClientProfileByClientIdTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedRestoringCode = HttpStatusCode.NoContent;
            //When
            _clientsClient.RestoringClientProfileByClientById(id, token, expectedRestoringCode);
        }

        public List<ClientsGetAllResponseModel> FindAddedClientProfileInListTest(string token, ClientsGetAllResponseModel expectedClient)
        {
            //When
            HttpContent content = _clientsClient.GetAllClients(token, HttpStatusCode.OK);
            List<ClientsGetAllResponseModel> actualClients = JsonSerializer.Deserialize<List<ClientsGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            //Then
            CollectionAssert.Contains(actualClients, expectedClient);

            return actualClients;
        }

        public List<ClientsGetAllResponseModel> FindDeletedClientProfileInListTest(string token, ClientsGetAllResponseModel expectedClient)
        {
            //When
            HttpContent content = _clientsClient.GetAllClients(token, HttpStatusCode.OK);
            List<ClientsGetAllResponseModel> actualClients = JsonSerializer.Deserialize<List<ClientsGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            //Then
            CollectionAssert.DoesNotContain(actualClients, expectedClient);

            return actualClients;
        }

        public void RestoreSittersProfileBySitterIdTest(int sitterId, string adminToken)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;

            _sittersClient.RestoreSitterProfileBySitterId(sitterId, adminToken, expectedCode);
        }

        public List<SittersGetAllResponseModel> FindAddedSitterProfileInListTest(string token, SittersGetAllResponseModel expectedSitter)
        {
            //When
            HttpContent content = _sittersClient.GetAllSitters(token, HttpStatusCode.OK);
            List<SittersGetAllResponseModel> actualSiterrs = JsonSerializer.Deserialize<List<SittersGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            //Then
            CollectionAssert.Contains(actualSiterrs, expectedSitter);

            return actualSiterrs;
        }

        public List<SittersGetAllResponseModel> FindDeletedSitterProfileInListTest(string token, SittersGetAllResponseModel expectedSitter)
        {
            //When
            HttpContent content = _sittersClient.GetAllSitters(token, HttpStatusCode.OK);
            List<SittersGetAllResponseModel> actualSiterrs = JsonSerializer.Deserialize<List<SittersGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            //Then
            CollectionAssert.DoesNotContain(actualSiterrs, expectedSitter);

            return actualSiterrs;
        }
    }
}
