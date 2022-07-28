using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class OrderingServicesTests
    {
        private ClientSteps _clientSteps = new ClientSteps();
        private Authorizations _authorization = new Authorizations();

        [Test]
        public void OrderingServicesWalking_WhenOrderModelIsCorrect_ShouldOrderingServicesWalking()
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

            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = clientId,
            };
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            AnimalAllInfoResponseModel expectedAnimal = new AnimalAllInfoResponseModel()
            {
                Id = animalId,
                Name = animalModel.Name,
                Age = animalModel.Age,
                RecommendationsForCare = animalModel.RecommendationsForCare,
                Breed = animalModel.Breed,
                Size = animalModel.Size,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoAnimalById(animalId, token, expectedAnimal);

            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = clientId,
                SitterId = 1,
                Type = 1,
                Date = DateTime.UtcNow,
                Address = clientModel.Address,
                Animals = new List<AnimalRegistrationRequestModel>()
                {
                    animalModel,
                }
            };
            int orderId = _clientSteps.RegisterOrder(orderModel);

            OrderAllInfoResponseModel expectedOrder = new OrderAllInfoResponseModel()
            {
                Id = orderId,
                ClienId = clientId,
                SitterId = 1,
                Type = orderModel.Type,
                Status = 1,
                Price = 555,
                Date = orderModel.Date,
                Address = orderModel.Address,
                Animals = new List<AnimalAllInfoResponseModel>()
                {
                    expectedAnimal,
                },
                Comments = null,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoOrderById(orderId, token, expectedOrder);
        }
    }
}
