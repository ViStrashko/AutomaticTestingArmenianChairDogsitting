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

        public ClientSteps()
        {
            _clientsClient = new ClientsClient();
            _animalsClient = new AnimalsClient();
            _ordersClient = new OrdersClient();
            _commentsClient = new CommentsClient();
        }

        public int RegisterClientTest(ClientRegistrationRequestModel model)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _clientsClient.RegisterClient(model, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public ClientAllInfoResponseModel GetAllInfoClientByIdTest(int id, string token, ClientAllInfoResponseModel expectedClient)
        {
            //When
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedClient, actualClient);

            return actualClient;
        }

        public void UpdateClientByIdTest(int id, ClientUpdateRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _clientsClient.UpdateClientById(id, model, token, expectedUpdateCode);
        }

        public void DeleteClientByIdTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _clientsClient.DeleteClientById(id, token, expectedUpdateCode);
        }

        public int RegisterAnimalToClientProfileTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _animalsClient.RegisterAnimalToClientProfile(model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public AnimalAllInfoResponseModel GetAllInfoAnimalByIdTest(int id, string token, AnimalAllInfoResponseModel expectedAnimal)
        {
            //When
            HttpContent content = _animalsClient.GetAllInfoAnimalById(id, token, HttpStatusCode.OK);
            AnimalAllInfoResponseModel actualAnimal = JsonSerializer.Deserialize<AnimalAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedAnimal, actualAnimal);

            return actualAnimal;
        }

        public List<ClientsAnimalsResponseModel> FindAddedAnimalInListTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            //When
            HttpContent content = _animalsClient.GetAnimalsByClientId(id, token, HttpStatusCode.OK);
            List<ClientsAnimalsResponseModel> actualAnimals = JsonSerializer.Deserialize<List<ClientsAnimalsResponseModel>>(content.ReadAsStringAsync().Result)!;
            //Then
            CollectionAssert.Contains(actualAnimals, expectedAnimal);

            return actualAnimals;
        }

        public List<ClientsAnimalsResponseModel> FindAddedAnimalInClientProfileTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            //When
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<ClientsAnimalsResponseModel> actualAnimals = actualClient.Dogs;
            //Then
            CollectionAssert.Contains(actualAnimals, expectedAnimal);

            return actualAnimals;
        }

        public List<ClientsAnimalsResponseModel> FindDeletedAnimalInListTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            //When
            HttpContent content = _animalsClient.GetAnimalsByClientId(id, token, HttpStatusCode.OK);
            List<ClientsAnimalsResponseModel> actualAnimals = JsonSerializer.Deserialize<List<ClientsAnimalsResponseModel>>(content.ReadAsStringAsync().Result)!;
            //Then
            CollectionAssert.DoesNotContain(actualAnimals, expectedAnimal);

            return actualAnimals;
        }

        public List<ClientsAnimalsResponseModel> FindDeletedAnimalInClientProfileTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            //When
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<ClientsAnimalsResponseModel> actualAnimals = actualClient.Dogs;
            //Then
            CollectionAssert.DoesNotContain(actualAnimals, expectedAnimal);

            return actualAnimals;
        }

        public void UpdateAnimalByIdTest(int id, AnimalUpdateRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _animalsClient.UpdateAnimalById(id, model, token, expectedUpdateCode);
        }

        public void DeleteAnimalByIdTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _animalsClient.DeleteAnimalById(id, token, expectedUpdateCode);
        }

        public int RegisterOrderTest(OrderRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _ordersClient.RegisterOrder(model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public OrderAllInfoResponseModel GetAllInfoOrderByIdTest(int id, string token, OrderAllInfoResponseModel expectedOrder)
        {
            //When
            HttpContent content = _ordersClient.GetAllInfoOrderById(id, token, HttpStatusCode.OK);
            OrderAllInfoResponseModel actualOrder = JsonSerializer.Deserialize<OrderAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedOrder, actualOrder);

            return actualOrder;
        }

        public List<ClientsAnimalsResponseModel> FindAddedAnimalInOrderTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            //When
            HttpContent content = _ordersClient.GetAllInfoOrderById(id, token, HttpStatusCode.OK);
            OrderAllInfoResponseModel actualOrder = JsonSerializer.Deserialize<OrderAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<ClientsAnimalsResponseModel> actualAnimals = actualOrder.Animals;
            //Then
            CollectionAssert.Contains(actualAnimals, expectedAnimal);

            return actualAnimals;
        }

        public List<ClientsAnimalsResponseModel> FindDeletedAnimalInOrderTest(int id, string token, ClientsAnimalsResponseModel expectedAnimal)
        {
            //When
            HttpContent content = _ordersClient.GetAllInfoOrderById(id, token, HttpStatusCode.OK);
            OrderAllInfoResponseModel actualOrder = JsonSerializer.Deserialize<OrderAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<ClientsAnimalsResponseModel> actualAnimals = actualOrder.Animals;
            //Then
            CollectionAssert.DoesNotContain(actualAnimals, expectedAnimal);

            return actualAnimals;
        }

        public List<OrderAllInfoResponseModel> FindAddedOrderInClientTest(int id, string token, OrderAllInfoResponseModel expectedOrder)
        {
            //When
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<OrderAllInfoResponseModel> actualOrders = actualClient.Orders;
            //Then
            CollectionAssert.Contains(actualOrders, expectedOrder);

            return actualOrders;
        }

        public List<OrderAllInfoResponseModel> FindDeletedOrderInClientTest(int id, string token, OrderAllInfoResponseModel expectedOrder)
        {
            //When
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            List<OrderAllInfoResponseModel> actualOrders = actualClient.Orders;
            //Then
            CollectionAssert.DoesNotContain(actualOrders, expectedOrder);

            return actualOrders;
        }

        public int RegisterCommentToOrderTest(int id, CommentRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _ordersClient.RegisterCommentToOrder(id, model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public List<CommentAllInfoResponseModel> FindAddedCommentByOrderIdTest(int id, string token, CommentAllInfoResponseModel expectedComment)
        {
            //When
            HttpContent content = _ordersClient.GetAllInfoCommentsByOrderId(id, token, HttpStatusCode.OK);
            List<CommentAllInfoResponseModel> actualComments = JsonSerializer.Deserialize<List<CommentAllInfoResponseModel>>(content.ReadAsStringAsync().Result)!;
            //Then
            CollectionAssert.Contains(actualComments, expectedComment);

            return actualComments;
        }

        public List<CommentAllInfoResponseModel> FindDeletedCommentByOrderIdTest(int id, string token, CommentAllInfoResponseModel expectedComment)
        {
            //When
            HttpContent content = _ordersClient.GetAllInfoCommentsByOrderId(id, token, HttpStatusCode.OK);
            List<CommentAllInfoResponseModel> actualComments = JsonSerializer.Deserialize<List<CommentAllInfoResponseModel>>(content.ReadAsStringAsync().Result)!;
            //Then
            CollectionAssert.DoesNotContain(actualComments, expectedComment);
            return actualComments;
        }

        public void UpdateOrderStatusByOrderIdTest(int id, int ststusUpdate, string token, OrderUpdateRequestModel model)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _ordersClient.UpdateOrderStatusByOrderId(id, ststusUpdate, token, expectedUpdateCode);
        }

        public void UpdateOrderByIdTest(int id, OrderUpdateRequestModel model,  string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _ordersClient.UpdateOrderById(id, model, token, expectedUpdateCode);
        }

        public void DeleteOrderByIdTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _ordersClient.DeleteOrderById(id, token, expectedUpdateCode);
        }

        public void DeleteCommentByIdTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _commentsClient.DeleteCommentById(id, token, expectedUpdateCode);
        }
    }
}
