using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Clients;
using System.Net;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class ClientNegativeSteps
    {
        private ClientsClient _clientsClient;
        private AnimalsClient _animalsClient;
        private OrdersClient _ordersClient;
        private CommentsClient _commentsClient;

        public ClientNegativeSteps()
        {
            _clientsClient = new ClientsClient();
            _animalsClient = new AnimalsClient();
            _ordersClient = new OrdersClient();
            _commentsClient = new CommentsClient();
        }

        public void RegisterClientNegativeTest(ClientRegistrationRequestModel model)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.UnprocessableEntity;
            _clientsClient.RegisterClient(model, expectedRegistrationCode);
        }

        public void EditingClientsPropertyNegativeTest(ClientUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.UnprocessableEntity;
            _clientsClient.UpdateClient(model, token, expectedUpdatedCode);
        }

        public void EditingClientProfileBySitterOrAdminOrAnonimNegativeTest(ClientUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdatedCode;
            if (token != null)
            {
                expectedUpdatedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedUpdatedCode = HttpStatusCode.Unauthorized;
            }
            _clientsClient.UpdateClient(model, token, expectedUpdatedCode);
        }

        public void DeleteClientProfileBySitterOrAnonimNegativeTest(string token)
        {
            HttpStatusCode expectedDeletedCode;
            if (token != null)
            {
                expectedDeletedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedDeletedCode = HttpStatusCode.Unauthorized;
            }
            _clientsClient.DeleteClient(token, expectedDeletedCode);
        }

        public void AddingClientProfileByClientOrAdminNegativeTest(ClientRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Forbidden;
            _clientsClient.RegisterClientWithToken(model, token, expectedRegistrationCode);
        }

        public void GetClientProfilesByClientOrSitterOrAnonimNegativeTest(string token)
        {
            HttpStatusCode expectedCode;
            if (token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _clientsClient.GetAllClients(token, expectedCode);
        }

        public void GetClientProfileByClientIdWhenClientIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            _clientsClient.GetAllInfoClientById(id, token, expectedCode);
        }

        public void GetClientProfileByClientIdBySitterOrAlienClientOrAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode;
            if (token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _clientsClient.GetAllInfoClientById(id, token, expectedCode);
        }

        public void RestoreClientProfileBySitterOrClientOrAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode;
            if(token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _clientsClient.RestoringClientProfileByClientById(id, token, expectedCode);
        }

        public void RestoreClientProfileWithNotCorrectIdTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.BadRequest;
            _clientsClient.RestoringClientProfileByClientById(id, token, expectedCode);
        }

        public void ChangeClientPasswordWhenPasswordModelIsNotCorrectNegativeTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _clientsClient.UpdateClientsPassword(model, token, expectedCode);
        }

        public void ChangeClientPasswordBySitterOrAdminOrAnonimNegativeTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedCode;
            if (token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;

            }
            _clientsClient.UpdateClientsPassword(model, token, expectedCode);
        }

        public void RegisterAnimalWhenAnimalsPropertyEmptyAndNotCorrectNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.UnprocessableEntity;
            _animalsClient.RegisterAnimalToClientProfile(model, token, expectedRegistrationCode);
        }

        public void RegisterAnimalWhenClientIdIsNotCorrectNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.BadRequest;
            _animalsClient.RegisterAnimalToClientProfile(model, token, expectedRegistrationCode);
        }

        public void RegisterAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(AnimalRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode;
            if(token != null)
            {
                expectedRegistrationCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedRegistrationCode = HttpStatusCode.Unauthorized;
            }
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

        public void EditingAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(int id, AnimalUpdateRequestModel animalUpdateModel, string token)
        {
            HttpStatusCode expectedUpdatedCode;
            if(token != null)
            {
                expectedUpdatedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedUpdatedCode = HttpStatusCode.Unauthorized;
            }
            _animalsClient.UpdateAnimalById(id, animalUpdateModel, token, expectedUpdatedCode);
        }

        public void DeleteAnimalWhenAnimalIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedDeletedCode = HttpStatusCode.BadRequest;
            _animalsClient.DeleteAnimalById(id, token, expectedDeletedCode);
        }

        public void DeleteAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedDeletedCode;
            if(token != null)
            {
                expectedDeletedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedDeletedCode = HttpStatusCode.Unauthorized;
            }
            _animalsClient.DeleteAnimalById(id, token, expectedDeletedCode);
        }

        public void GetAnimalWhenAnimalIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            _animalsClient.GetAllInfoAnimalById(id, token, expectedCode);
        }

        public void GetAnimalBySitterOrAlienClientOrAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode;
            if(token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _animalsClient.GetAllInfoAnimalById(id, token, expectedCode);
        }

        public void GetAnimalsWhenClientIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            _animalsClient.GetAnimalsByClientId(id, token, expectedCode);
        }

        public void GetAnimalsBySitterOrAlienClientOrAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode;
            if(token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _animalsClient.GetAnimalsByClientId(id, token, expectedCode);
        }

        public void RestoreAnimalWhenAnimalIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.BadRequest;
            _animalsClient.RestoreAnimalById(id, token, expectedCode);
        }

        public void RestoreAnimalBySitterOrAlienClientOrAnonimOrAdminNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode;
            if (token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _animalsClient.GetAnimalsByClientId(id, token, expectedCode);
        }

        public void OrderingServicesWhenTwoServicesForSameDogNegativeTest
            (OrderWalkRegistrationRequestModel orderWalkModel, OrderOverexposeRegistrationRequestModel orderOverexposeModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.BadRequest;
            _ordersClient.RegisterOrderWalk(orderWalkModel, token, expectedCode);
            _ordersClient.RegisterOrderOverexpose(orderOverexposeModel, token, expectedCode);
        }

        public void OrderingServicesWhenPastOrderServiceDateAndTimeNegativeTest(OrderWalkRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _ordersClient.RegisterOrderWalk(model, token, expectedCode);
        }
    }
}
