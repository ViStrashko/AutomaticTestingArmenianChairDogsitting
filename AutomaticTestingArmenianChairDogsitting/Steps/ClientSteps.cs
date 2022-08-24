using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Clients;
using System;
using System.Net;
using System.Net.Http;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Text.Json;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class ClientSteps
    {
        private ClientsClient _clientsClient;
        private AnimalsClient _animalsClient;
        private OrdersClient _ordersClient;
        private CommentsClient _commentsClient;
        private SearchClient _searchClient;
        private DateTime _oneActualTime = DateTime.Now.AddSeconds(1);
        private DateTime _twoActualTime = DateTime.Now.AddSeconds(2);
        private DateTime _threeActualTime = DateTime.Now.AddSeconds(3);
        private DateTime _fourActualTime = DateTime.Now.AddSeconds(4);
        private DateTime _fiveActualTime = DateTime.Now.AddSeconds(5);


        public ClientSteps()
        {
            _clientsClient = new ClientsClient();
            _animalsClient = new AnimalsClient();
            _ordersClient = new OrdersClient();
            _commentsClient = new CommentsClient();
            _searchClient = new SearchClient();
        }

        public int RegisterClientTest(ClientRegistrationRequestModel model)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _clientsClient.RegisterClient(model, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }

        public ClientAllInfoResponseModel GetAllInfoClientByIdTest(int id, string token, ClientAllInfoResponseModel expectedClient)
        {
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.AreEqual(actualClient.Dogs, expectedClient.Dogs);
            CollectionAssert.AreEqual(actualClient.Orders, expectedClient.Orders);
            Assert.AreEqual(expectedClient, actualClient);
            return actualClient;
        }

        public void UpdateClientTest(ClientUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _clientsClient.UpdateClient(model, token, expectedUpdateCode);
        }

        public void DeleteClientTest(string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _clientsClient.DeleteClient(token, expectedDeleteCode);
        }

        public void ChangeClientsPasswordTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _clientsClient.UpdateClientsPassword(model, token, expectedUpdateCode);
        }

        public int RegisterAnimalToClientProfileTest(AnimalRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _animalsClient.RegisterAnimalToClientProfile(model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }

        public AnimalAllInfoResponseModel GetAllInfoAnimalByIdTest(int id, string token, AnimalAllInfoResponseModel expectedAnimal)
        {
            HttpContent content = _animalsClient.GetAllInfoAnimalById(id, token, HttpStatusCode.OK);
            AnimalAllInfoResponseModel actualAnimal = JsonSerializer.Deserialize<AnimalAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            Assert.AreEqual(expectedAnimal, actualAnimal);
            return actualAnimal;
        }

        public List<ClientsAnimalsResponseModel> FindAddedAnimalInListTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            HttpContent content = _animalsClient.GetAnimalsByClientId(id, token, HttpStatusCode.OK);
            List<ClientsAnimalsResponseModel> actualAnimals = JsonSerializer.Deserialize<List<ClientsAnimalsResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.Contains(actualAnimals, expectedAnimal);
            return actualAnimals;
        }

        public List<ClientsAnimalsResponseModel> FindAddedAnimalInClientProfileTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<ClientsAnimalsResponseModel> actualAnimals = actualClient.Dogs;
            CollectionAssert.Contains(actualAnimals, expectedAnimal);
            return actualAnimals;
        }

        public List<ClientsAnimalsResponseModel> FindDeletedAnimalInListTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            HttpContent content = _animalsClient.GetAnimalsByClientId(id, token, HttpStatusCode.OK);
            List<ClientsAnimalsResponseModel> actualAnimals = JsonSerializer.Deserialize<List<ClientsAnimalsResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.DoesNotContain(actualAnimals, expectedAnimal);
            return actualAnimals;
        }

        public List<ClientsAnimalsResponseModel> FindDeletedAnimalInClientProfileTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<ClientsAnimalsResponseModel> actualAnimals = actualClient.Dogs;
            CollectionAssert.DoesNotContain(actualAnimals, expectedAnimal);
            return actualAnimals;
        }

        public void UpdateAnimalByIdTest(int id, AnimalUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _animalsClient.UpdateAnimalById(id, model, token, expectedUpdateCode);
        }

        public void DeleteAnimalByIdTest(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _animalsClient.DeleteAnimalById(id, token, expectedDeleteCode);
        }

        public void RestoreAnimalByIdTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;
            _animalsClient.RestoreAnimalById(id, token, expectedCode);
        }

        public int RegisterOrderWalkTest(OrderWalkRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _ordersClient.RegisterOrderWalk(model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }

        public int RegisterOrderOverexposeTest(OrderOverexposeRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _ordersClient.RegisterOrderOverexpose(model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }

        public int RegisterOrderDailySittingTest(OrderDailySittingRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _ordersClient.RegisterOrderDailySitting(model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }

        public int RegisterOrderSittingForADayTest(OrderSittingForADayRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _ordersClient.RegisterOrderDailySittingForADay(model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }

        public OrderAllInfoResponseModel GetAllInfoOrderByIdTest(int id, string token, OrderAllInfoResponseModel expectedOrder)
        {
            HttpContent content = _ordersClient.GetAllInfoOrderById(id, token, HttpStatusCode.OK);
            OrderAllInfoResponseModel actualOrder = JsonSerializer.Deserialize<OrderAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            if(actualOrder.WorkDate == _oneActualTime || actualOrder.WorkDate == _twoActualTime || actualOrder.WorkDate == _threeActualTime
               || actualOrder.WorkDate == _fourActualTime || actualOrder.WorkDate == _fiveActualTime
               || actualOrder.DateUpdated == expectedOrder.DateUpdated.AddSeconds(1) || actualOrder.DateUpdated == expectedOrder.DateUpdated.AddSeconds(2)
               || actualOrder.DateUpdated == expectedOrder.DateUpdated.AddSeconds(3) || actualOrder.DateUpdated == expectedOrder.DateUpdated.AddSeconds(4)
               || actualOrder.DateUpdated == expectedOrder.DateUpdated.AddSeconds(5))
            {
                actualOrder.WorkDate = expectedOrder.WorkDate;
                actualOrder.DateUpdated = expectedOrder.DateUpdated;
            }
            Assert.AreEqual(expectedOrder, actualOrder);
            return actualOrder;
        }

        public List<ClientsAnimalsResponseModel> FindAddedAnimalInOrderTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            HttpContent content = _ordersClient.GetAllInfoOrderById(id, token, HttpStatusCode.OK);
            OrderAllInfoResponseModel actualOrder = JsonSerializer.Deserialize<OrderAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<ClientsAnimalsResponseModel> actualAnimals = actualOrder.Animals;
            CollectionAssert.Contains(actualAnimals, expectedAnimal);
            return actualAnimals;
        }

        public List<ClientsAnimalsResponseModel> FindDeletedAnimalInOrderTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            HttpContent content = _ordersClient.GetAllInfoOrderById(id, token, HttpStatusCode.OK);
            OrderAllInfoResponseModel actualOrder = JsonSerializer.Deserialize<OrderAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<ClientsAnimalsResponseModel> actualAnimals = actualOrder.Animals;
            CollectionAssert.DoesNotContain(actualAnimals, expectedAnimal);
            return actualAnimals;
        }

        public List<OrderAllInfoResponseModel> FindAddedOrderInClientTest(int id, string token, OrderAllInfoResponseModel expectedOrder)
        {
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<OrderAllInfoResponseModel> actualOrders = actualClient.Orders;
            CollectionAssert.Contains(actualOrders, expectedOrder);
            return actualOrders;
        }

        public List<OrderAllInfoResponseModel> FindDeletedOrderInClientTest(int id, string token, OrderAllInfoResponseModel expectedOrder)
        {
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<OrderAllInfoResponseModel> actualOrders = actualClient.Orders;
            CollectionAssert.DoesNotContain(actualOrders, expectedOrder);
            return actualOrders;
        }

        public int RegisterCommentToOrderTest(int id, CommentRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _ordersClient.RegisterCommentToOrder(id, model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }
                
        public void UpdateOrderWalkByIdTest(int id, OrderWalkUpdateRequestModel model,  string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _ordersClient.UpdateOrderWalkById(id, model, token, expectedUpdateCode);
        }

        public void UpdateOrderOverexposeByIdTest(int id, OrderOverexposeUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _ordersClient.UpdateOrderOverexposeById(id, model, token, expectedUpdateCode);
        }

        public void UpdateOrderDailySittingByIdTest(int id, OrderDailySittingUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _ordersClient.UpdateOrderDailySittingById(id, model, token, expectedUpdateCode);
        }

        public void UpdateOrderSittingForADayByIdTest(int id, OrderSittingForADayUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _ordersClient.UpdateOrderSittingForADayById(id, model, token, expectedUpdateCode);
        }

        public void DeleteOrderByIdTest(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _ordersClient.DeleteOrderById(id, token, expectedDeleteCode);
        }

        public void DeleteCommentByIdTest(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _commentsClient.DeleteCommentById(id, token, expectedDeleteCode);
        }

        public List<SittersGetAllResponseModel> SearchSittersTest(SearchRequestModel model, string token, List<SittersGetAllResponseModel> expectedSitters)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.OK;
            HttpContent content = _searchClient.SearchSitters(model, token, expectedDeleteCode);
            List<SittersGetAllResponseModel> actualSitters = JsonSerializer.Deserialize<List<SittersGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.AreEqual(actualSitters, expectedSitters);
            return actualSitters;
        }
    }
}
