using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class RegistrationTests
    {
        private ClientSteps _clientSteps = new ClientSteps();
        private Authorizations _authorization = new Authorizations();

        [Test]
        public void ClientCreation_WhenClientModelIsCorrect_ShouldCreateClient()
        {
            ClientRegisrationRequestModel clientModel = new ClientRegisrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "12345678",
            };
            int clientId = _clientSteps.RegisterClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = clientModel.Email,
                Password = clientModel.Password,
            };
            string token = _authorization.Authorize(authModel);

            ClientAllInfoResponseModel expectedClient = new ClientAllInfoResponseModel()
            {
                Id = clientId,
                Name = clientModel.Name,
                LastName = clientModel.LastName,
                Phone = clientModel.Phone,
                Address = clientModel.Address,
                Email = clientModel.Email,
                RegistrationDate = DateTime.Now.Date,
                Dogs = null,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoClientById(clientId, token, expectedClient);
        }
    }
}
