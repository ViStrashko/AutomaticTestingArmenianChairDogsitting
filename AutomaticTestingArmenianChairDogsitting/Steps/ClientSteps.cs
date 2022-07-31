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
        private ClientSteps _clientSteps;
        private ClientsClient _clientsClient = new ClientsClient();
        private AnimalsClient _animalsClient = new AnimalsClient();
        private OrdersClient _ordersClient = new OrdersClient();

        public ClientSteps()
        {
            _clientSteps = new ClientSteps();
        }

        public int RegisterClient(ClientRegisrationRequestModel model)
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
    }
}
