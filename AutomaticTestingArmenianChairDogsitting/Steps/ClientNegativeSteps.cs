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
    }
}
