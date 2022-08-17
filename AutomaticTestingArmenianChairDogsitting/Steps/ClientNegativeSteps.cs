using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Clients;
using System.Net;
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

        public ClientNegativeSteps()
        {
            _clientsClient = new ClientsClient();
            _sittersClient = new SittersClient();
            _animalsClient = new AnimalsClient();
            _ordersClient = new OrdersClient();
            _commentsClient = new CommentsClient();
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

        public void EditingClientProfileByClientIdWhenClientIdIsNotCorrectNegativeTest(int id, ClientUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.BadRequest;
            _clientsClient.UpdateClientById(id, model, token, expectedUpdatedCode);
        }

        public void EditingClientProfileBySitterOrAlienClientOrAdminNegativeTest(int id, ClientUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.Forbidden;
            _clientsClient.UpdateClientById(id, model, token, expectedUpdatedCode);
        }

        public void EditingClientProfileByAnonimNegativeTest(int id, ClientUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.Unauthorized;
            _clientsClient.UpdateClientById(id, model, token, expectedUpdatedCode);
        }

        public void DeleteClientProfileByClientIdWhenClientIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedDeletedCode = HttpStatusCode.BadRequest;
            _clientsClient.DeleteClientById(id, token, expectedDeletedCode);
        }

        public void DeleteClientProfileBySitterOrAlienClientNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedDeletedCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.DeleteClientById(id, token, expectedDeletedCode);
        }

        public void DeleteClientProfileByAnonimNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedDeletedCode = HttpStatusCode.Unauthorized;
            //When
            _clientsClient.DeleteClientById(id, token, expectedDeletedCode);
        }

        public void AddingClientProfileByClientOrAdminNegativeTest(ClientRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.RegisterClientWithToken(model, token, expectedRegistrationCode);
        }

        public void GetClientProfilesByClientOrSitterNegativeTest(string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.GetAllClients(token, expectedCode);
        }

        public void GetClientProfilesByAnonimNegativeTest(string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
            //When
            _clientsClient.GetAllClients(token, expectedCode);
        }

        public void GetClientProfileByClientIdWhenClientIdIsNotCorrectNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            //When
            _clientsClient.GetAllInfoClientById(id, token, expectedCode);
        }

        public void GetClientProfileByClientIdBySitterOrAlienClientNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.GetAllInfoClientById(id, token, expectedCode);
        }

        public void GetClientProfileByClientIdByAnonimNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
            //When
            _clientsClient.GetAllInfoClientById(id, token, expectedCode);
        }

        public void RestoreClientProfileBySitterOrClientNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            _clientsClient.RestoringClientProfileByClientById(id, token, expectedCode);
        }

        public void RestoreClientProfileByAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
            _clientsClient.RestoringClientProfileByClientById(id, token, expectedCode);
        }

        public void RestoreClientProfileWithNotCorrectIdTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.BadRequest;
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

        public void RegisterAnimalBySitterOrAdminNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Forbidden;
            //When
            _animalsClient.RegisterAnimalToClientProfile(model, token, expectedRegistrationCode);
        }

        public void RegisterAnimalByAnonimNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Unauthorized;
            //When
            _animalsClient.RegisterAnimalToClientProfile(model, token, expectedRegistrationCode);
        }

        public void EditingAnimalWhenAnimalsPropertyEmptyAndNotCorrectNegativeTest(int id, AnimalUpdateRequestModel animalUpdateModel, string token)
        {
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.UnprocessableEntity;

            _animalsClient.UpdateAnimalById(id, animalUpdateModel, token, expectedUpdatedCode);
        }

        public void EditingAnimalWhenAnimalIdIsNotCorrectNegativeTest(int id, AnimalUpdateRequestModel animalUpdateModel, string token)
        {
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.BadRequest;

            _animalsClient.UpdateAnimalById(id, animalUpdateModel, token, expectedUpdatedCode);
        }

        public void EditingAnimalBySitterOrAdminNegativeTest(int id, AnimalUpdateRequestModel animalUpdateModel, string token)
        {
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.Forbidden;

            _animalsClient.UpdateAnimalById(id, animalUpdateModel, token, expectedUpdatedCode);
        }
        public void EditingAnimalByAnonimNegativeTest(int id, AnimalUpdateRequestModel animalUpdateModel, string token)
        {
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.Unauthorized;

            _animalsClient.UpdateAnimalById(id, animalUpdateModel, token, expectedUpdatedCode);
        }

        public void DeleteAnimalWhenAnimalIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedDeletedCode = HttpStatusCode.BadRequest;

            _animalsClient.DeleteAnimalById(id, token, expectedDeletedCode);
        }

        public void DeleteAnimalBySitterOrAdminNegativeTest(int id, string token)
        {
            HttpStatusCode expectedDeletedCode = HttpStatusCode.Forbidden;

            _animalsClient.DeleteAnimalById(id, token, expectedDeletedCode);
        }

        public void DeleteAnimalByAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedDeletedCode = HttpStatusCode.Unauthorized;

            _animalsClient.DeleteAnimalById(id, token, expectedDeletedCode);
        }

        public void GetAnimalWhenAnimalIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;

            _animalsClient.GetAllInfoAnimalById(id, token, expectedCode);
        }

        public void GetAnimalBySitterOrAdminNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;

            _animalsClient.GetAllInfoAnimalById(id, token, expectedCode);
        }

        public void GetAnimalByAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;

            _animalsClient.GetAllInfoAnimalById(id, token, expectedCode);
        }

        public void GetAnimalsWhenClientIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;

            _animalsClient.GetAnimalsByClientId(id, token, expectedCode);
        }

        public void GetAnimalsBySitterOrAdminNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            
            _animalsClient.GetAnimalsByClientId(id, token, expectedCode);
        }

        public void GetAnimalsByAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;

            _animalsClient.GetAnimalsByClientId(id, token, expectedCode);
        }
    }
}
