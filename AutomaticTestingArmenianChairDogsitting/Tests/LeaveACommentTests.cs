using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class LeaveACommentTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;

        public LeaveACommentTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
        }

        [Test]
        public void LeaveCommentOnServicesWalking_WhenCommentModelIsCorrect_ShouldLeaveCommentOnServicesWalking()
        {
            ClientRegistrationRequestModel clientModel = new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "12345678",
            };
            int clientId = _clientSteps.RegisterClientTest(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = clientModel.Email,
                Password = clientModel.Password,
            };
            string token = _authorization.AuthorizeTest(authModel);

            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = clientId,
            };
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(animalModel, token);
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

            SitterRegistrationRequestModel sitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Email = "pet@gmail.com",
                Phone = "+79514125547",
                Age = 20,
                Description = "Description",
                Experience = 10,
                Sex = 1,
                Password = "12345678",
            };
            int sitterId = _sitterSteps.RegisterSitterTest(sitterModel);

            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = clientId,
                SitterId = sitterId,
                Date = DateTime.UtcNow,
                Address = clientModel.Address,
                Animals = new List<int>()
                {
                    animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(orderModel, token);

            CommentRegistrationRequestModel commentModel = new CommentRegistrationRequestModel()
            {
                Rating = 5,
                Text = "Собачка была под хорошим присмотром, и я не порвала себе сердце от беспокойства за неё.",
            };
            int commentId = _clientSteps.RegisterCommentToOrderTest(orderId, commentModel, token);

            OrderAllInfoResponseModel expectedOrder = new OrderAllInfoResponseModel()
            {
                Id = orderId,
                ClienId = clientId,
                SitterId = sitterId,
                Type = orderModel.Type,
                Status = 1,
                Date = orderModel.Date,
                Address = orderModel.Address,
                Animals = new List<ClientsAnimalsResponseModel>()
                {
                    //expectedAnimal,
                },
                Comments = new List<CommentResponseModel>()
                {
                    new CommentResponseModel()
                    {
                        Id = commentId,
                        Rating = commentModel.Rating,
                        Text = commentModel.Text,
                    }
                },
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoOrderByIdTest(orderId, token, expectedOrder);
        }
    }
}
