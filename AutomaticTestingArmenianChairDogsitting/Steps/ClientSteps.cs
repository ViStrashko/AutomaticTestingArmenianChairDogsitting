using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Clients;
using System;
using System.Net;
using System.Net.Http;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Text.Json;

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

    public int RegisterClient(ClientRegistrationRequestModel model)
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

        public ClientAllInfoResponseModel GetAllInfoClientById(int id, string token, ClientAllInfoResponseModel expectedClient)
        {
            //When
            HttpContent content = _clientsClient.GetAllInfoClientById(id, token, HttpStatusCode.OK);
            ClientAllInfoResponseModel actualClient = JsonSerializer.Deserialize<ClientAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedClient, actualClient);

            return actualClient;
        }

        public void UpdateClientById(int id, string token, ClientUpdateRequestModel model)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _clientsClient.UpdateClientById(id, token, model, expectedUpdateCode);
        }

        public void DeleteClientById(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _clientsClient.DeleteClientById(id, token, expectedUpdateCode);
        }

        public int RegisterAnimalToClientProfile(AnimalRegistrationRequestModel model)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _animalsClient.RegisterAnimalToClientProfile(model, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public AnimalAllInfoResponseModel GetAllInfoAnimalById(int id, string token, AnimalAllInfoResponseModel expectedAnimal)
        {
            //When
            HttpContent content = _animalsClient.GetAllInfoAnimalById(id, token, HttpStatusCode.OK);
            AnimalAllInfoResponseModel actualAnimal = JsonSerializer.Deserialize<AnimalAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedAnimal, actualAnimal);

            return actualAnimal;
        }

        public ClientAnimalsResponseModels GetAnimalsByClientId(int id, string token, ClientAnimalsResponseModels expectedAnimals)
        {
            //When
            HttpContent content = _animalsClient.GetAnimalsByClientId(id, token, HttpStatusCode.OK);
            ClientAnimalsResponseModels actualAnimals = JsonSerializer.Deserialize<ClientAnimalsResponseModels>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedAnimals, actualAnimals);

            return actualAnimals;
        }

        public void UpdateAnimalById(int id, string token, AnimalUpdateRequestModel model)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _animalsClient.UpdateAnimalById(id, token, model, expectedUpdateCode);
        }

        public void DeleteAnimalById(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _animalsClient.DeleteAnimalById(id, token, expectedUpdateCode);
        }

        public int RegisterOrder(OrderRegistrationRequestModel model)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _ordersClient.RegisterOrder(model, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public OrderAllInfoResponseModel GetAllInfoOrderById(int id, string token, OrderAllInfoResponseModel expectedOrder)
        {
            //When
            HttpContent content = _ordersClient.GetAllInfoOrderById(id, token, HttpStatusCode.OK);
            OrderAllInfoResponseModel actualOrder = JsonSerializer.Deserialize<OrderAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedOrder, actualOrder);

            return actualOrder;
        }

        public void UpdateOrderById(int id, string token, OrderUpdateRequestModel model)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _ordersClient.UpdateOrderById(id, token, model, expectedUpdateCode);
        }

        public void DeleteOrderById(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _ordersClient.DeleteOrderById(id, token, expectedUpdateCode);
        }

        public int RegisterComment(CommentRegistrationRequestModel model)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _commentsClient.RegisterComment(model, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public CommentAllInfoResponseModel GetAllInfoCommentById(int id, string token, CommentAllInfoResponseModel expectedOrder)
        {
            //When
            HttpContent content = _commentsClient.GetAllInfoCommentById(id, token, HttpStatusCode.OK);
            CommentAllInfoResponseModel actualOrder = JsonSerializer.Deserialize<CommentAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedOrder, actualOrder);

            return actualOrder;
        }

        public void UpdateCommentById(int id, string token, CommentUpdateRequestModel model)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _commentsClient.UpdateCommentById(id, token, model, expectedUpdateCode);
        }

        public void DeleteCommentById(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _commentsClient.DeleteCommentById(id, token, expectedUpdateCode);
        }
    }
}
