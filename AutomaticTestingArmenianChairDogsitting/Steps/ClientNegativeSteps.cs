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

        public void EditingProfileByIncorrecUserIdNegativeTest(int id, ClientUpdateRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.BadRequest;
            //When
            _clientsClient.UpdateClientById(id, model, token, expectedUpdatedCode);
        }

        public void DeleteProfileByIncorrecUserIdNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedDeletedCode = HttpStatusCode.BadRequest;
            //When
            _clientsClient.DeleteClientById(id, token, expectedDeletedCode);
        }

        public void EditingAlienProfileByCorrectUserIdNegativeTest(int id, ClientUpdateRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdatedCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.UpdateClientById(id, model, token, expectedUpdatedCode);
        }

        public void DeleteAlienProfileByCorrectUserIdNegativeTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedDeletedCode = HttpStatusCode.Forbidden;
            //When
            _clientsClient.DeleteClientById(id, token, expectedDeletedCode);
        }
    }
}
