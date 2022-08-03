//using NUnit.Framework;
//using AutomaticTestingArmenianChairDogsitting.Models.Request;
//using AutomaticTestingArmenianChairDogsitting.Models.Response;
//using AutomaticTestingArmenianChairDogsitting.Steps;
//using System;
//using System.Collections.Generic;

//namespace AutomaticTestingArmenianChairDogsitting.Tests
//{
//    public class LeaveACommentTests
//    {
//        private Authorizations _authorization;
//        private ClientSteps _clientSteps;
//        private SitterSteps _sitterSteps;

//        public LeaveACommentTests()
//        {
//            _authorization = new Authorizations();
//            _clientSteps = new ClientSteps();
//            _sitterSteps = new SitterSteps();
//        }

//        [Test]
//        public void LeaveCommentOnServicesWalking_WhenCommentModelIsCorrect_ShouldLeaveCommentOnServicesWalking()
//        {
//            ClientRegistrationRequestModel clientModel = new ClientRegistrationRequestModel()
//            {
//                Name = "Вася",
//                LastName = "Петров",
//                Email = "petrov@gmail.com",
//                Phone = "+79514125547",
//                Address = "ул. Итальянская, дом. 10",
//                Password = "12345678",
//            };
//            int clientId = _clientSteps.RegisterClient(clientModel);

//            AuthRequestModel authModel = new AuthRequestModel()
//            {
//                Email = clientModel.Email,
//                Password = clientModel.Password,
//            };
//            string token = _authorization.Authorize(authModel);

//            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
//            {
//                Name = "Шарик",
//                Age = 1,
//                RecommendationsForCare = "Играть осторожно",
//                Breed = "Доберман",
//                Size = 5,
//                ClientId = clientId,
//            };
//            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);
//            AnimalAllInfoResponseModel expectedAnimal = new AnimalAllInfoResponseModel()
//            {
//                Id = animalId,
//                Name = animalModel.Name,
//                Age = animalModel.Age,
//                RecommendationsForCare = animalModel.RecommendationsForCare,
//                Breed = animalModel.Breed,
//                Size = animalModel.Size,
//                IsDeleted = false,
//            };

//            SitterRegistrationRequestModel sitterModel = new SitterRegistrationRequestModel()
//            {
//                Name = "Валера",
//                LastName = "Пет",
//                Email = "pet@gmail.com",
//                Phone = "+79514125547",
//                Age = 20,
//                Description = "Description",
//                Experience = 10,
//                Sex = 1,
//                PriceCatalog = new List<PriceCatalogRequestModel>()
//                {
//                    new PriceCatalogRequestModel()
//                    {
//                        Service = 1,
//                        Price = 500,
//                    },
//                },
//                Password = "12345678",
//            };
//            int sitterId = _sitterSteps.RegisterSitter(sitterModel);

//            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
//            {
//                ClienId = clientId,
//                SitterId = sitterId,
//                Type = sitterModel.PriceCatalog[1].Service,
//                Date = DateTime.UtcNow,
//                Address = clientModel.Address,
//                Animals = new List<AnimalRegistrationRequestModel>()
//                {
//                    animalModel,
//                }
//            };
//            int orderId = _clientSteps.RegisterOrder(orderModel);

//            CommentRegistrationRequestModel commentModel = new CommentRegistrationRequestModel()
//            {
//                ClientId = clientId,
//                OrderId = orderId,
//                Rating = 5,
//                Text = "Собачка была под хорошим присмотром, и я не порвала себе сердце от беспокойства за неё.",
//                TimeCreated = DateTime.UtcNow,
//            };
//            int commentId = _clientSteps.RegisterComment(commentModel);

//            OrderAllInfoResponseModel expectedOrder = new OrderAllInfoResponseModel()
//            {
//                Id = orderId,
//                ClienId = clientId,
//                SitterId = sitterId,
//                Type = orderModel.Type,
//                Status = 1,
//                Price = sitterModel.PriceCatalog[1].Price,
//                Date = orderModel.Date,
//                Address = orderModel.Address,
//                Animals = new List<AnimalAllInfoResponseModel>()
//                {
//                    expectedAnimal,
//                },
//                Comments = new List<CommentAllInfoResponseModel>()
//                {
//                    new CommentAllInfoResponseModel()
//                    {
//                        Id = commentId,
//                        ClientId = clientId,
//                        Rating = commentModel.Rating,
//                        Text = commentModel.Text,
//                        TimeCreated = commentModel.TimeCreated,
//                        TimeUpdated = null,
//                        IsDeleted = false,
//                    }
//                },
//                IsDeleted = false,
//            };
//            _clientSteps.GetAllInfoOrderById(orderId, token, expectedOrder);
//        }
//    }
//}
