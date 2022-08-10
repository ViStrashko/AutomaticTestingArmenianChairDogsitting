using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Clients;
using System.Net;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using System.Net.Http;
using System;
using NUnit.Framework;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class ClientNegativeSteps
    {
        private ClientsClient _clientsClient;
        private SittersClient _sittersClient;
        private AnimalsClient _animalsClient;
        private OrdersClient _ordersClient;
        private CommentsClient _commentsClient;
        private AnimalMappers _animalMappers;

        public ClientNegativeSteps()
        {
            _clientsClient = new ClientsClient();
            _sittersClient = new SittersClient();
            _animalsClient = new AnimalsClient();
            _ordersClient = new OrdersClient();
            _commentsClient = new CommentsClient();
            _animalMappers = new AnimalMappers();
        }

        public void RegisterClientNegativeTest(ClientRegistrationRequestModel model)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.UnprocessableEntity;
            //When
            _clientsClient.RegisterClient(model, expectedRegistrationCode);
        }

        public void EditingClientsPropertyNegativeTest(int id, ClientUpdateRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.UnprocessableEntity;
            //When
            _clientsClient.UpdateClientById(id, model, token, expectedUpdatedCode);
        }

        public void EditingClientProfileByClientIdNegativeTest(int id, ClientUpdateRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.UpdateClientById(id, model, token, expectedUpdatedCode);
        }

        public void DeleteClientProfileByClientIdNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedDeletedCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.DeleteClientById(id, token, expectedDeletedCode);
        }

        public void AddingNewClientProfileWhenAlreadyHaveClientProfileNegativeTest(string token, ClientRegistrationRequestModel model)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.RegisterClientWithToken(token, model, expectedRegistrationCode);
        }

        public void GetClientProfilesNegativeTest(string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            //When
            _clientsClient.GetAllClients(token, expectedCode);
        }

        public void GetClientProfileByClientIdNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            //When
            _clientsClient.GetAllInfoClientById(id, token, expectedCode);
        }

        public void RestoringClientProfileByClientByIdNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.RestoringClientProfileByClientById(id, token, expectedCode);
        }

        public void RegisterAnimalWhenAnimalsPropertyEmptyAndNotCorrectNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.UnprocessableEntity;
            //When
            _animalsClient.RegisterAnimalToClientProfile(model, token, expectedRegistrationCode);
        }

        public void RegisterAnimalWhenClientIdIsNotCorrectNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.BadRequest;
            //When
            _animalsClient.RegisterAnimalToClientProfile(model, token, expectedRegistrationCode);
        }

        public void EditingAnimalWhenAnimalsPropertyEmptyAndNotCorrectNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.UnprocessableEntity;
            //When
            HttpContent content = _animalsClient.RegisterAnimalToClientProfile(model, token, HttpStatusCode.Created);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            AnimalUpdateRequestModel animalUpdateModel = _animalMappers.MappAnimalRegistrationRequestModelToAnimalUpdateRequestModel(model);
            _animalsClient.UpdateAnimalById(actualId, animalUpdateModel, token, expectedUpdatedCode);
        }

        public void EditingAnimalWhenAnimalIdIsNotCorrectNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.BadRequest;
            //When
            HttpContent content = _animalsClient.RegisterAnimalToClientProfile(model, token, HttpStatusCode.Created);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            AnimalUpdateRequestModel animalUpdateModel = _animalMappers.MappAnimalRegistrationRequestModelToAnimalUpdateRequestModel(model);
            _animalsClient.UpdateAnimalById(actualId + 100, animalUpdateModel, token, expectedUpdatedCode);
        }

        public void DeleteAnimalWhenAnimalIdIsNotCorrectNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedDeletedCode = HttpStatusCode.BadRequest;
            //When
            HttpContent content = _animalsClient.RegisterAnimalToClientProfile(model, token, HttpStatusCode.Created);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            _animalsClient.DeleteAnimalById(actualId + 100, token, expectedDeletedCode);
        }

        public void GetAnimalWhenAnimalIdIsNotCorrectNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            //When
            HttpContent content = _animalsClient.RegisterAnimalToClientProfile(model, token, HttpStatusCode.Created);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            _animalsClient.GetAllInfoAnimalById(actualId + 100, token, expectedCode);
        }

        public void GetAnimalsWhenClientIdIsNotCorrectNegativeTest(int id, AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            //When
            _animalsClient.RegisterAnimalToClientProfile(model, token, HttpStatusCode.Created);

            _animalsClient.GetAnimalsByClientId(id, token, expectedCode);
        }
    }
}
