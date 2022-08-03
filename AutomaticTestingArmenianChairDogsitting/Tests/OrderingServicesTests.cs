//using NUnit.Framework;
//using AutomaticTestingArmenianChairDogsitting.Models.Request;
//using AutomaticTestingArmenianChairDogsitting.Models.Response;
//using AutomaticTestingArmenianChairDogsitting.Steps;
//using System;
//using System.Collections.Generic;

//namespace AutomaticTestingArmenianChairDogsitting.Tests
//{
//    public class OrderingServicesTests
//    {
//        private Authorizations _authorization;
//        private ClientSteps _clientSteps;
//        private SitterSteps _sitterSteps;

//        public OrderingServicesTests()
//        {
//            _authorization = new Authorizations();
//            _clientSteps = new ClientSteps();
//            _sitterSteps = new SitterSteps();
//        }

//        [Test]
//        public void OrderingServicesWalking_WhenOrderModelIsCorrect_ShouldOrderingServicesWalking()
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
//                Comments = null,
//                IsDeleted = false,
//            };
//            _clientSteps.GetAllInfoOrderById(orderId, token, expectedOrder);
//        }

//        [Test]
//        public void EditingServicesWalking_WhenChangeAddressAndOrderModelIsCorrect_ShouldEditingServicesWalking()
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

//            OrderUpdateRequestModel orderUpdateModel = new OrderUpdateRequestModel()
//            {
//                Address = "Каменноостровский проспект, дом 10",
//                Date = orderModel.Date,
//                Animals = new List<AnimalUpdateRequestModel>()
//                {
//                    new AnimalUpdateRequestModel()
//                    {
//                        Name = animalModel.Name,
//                        Age = animalModel.Age,
//                        RecommendationsForCare = animalModel.RecommendationsForCare,
//                        Breed = animalModel.Breed,
//                        Size = animalModel.Size,
//                    },
//                },
//            };
//            _clientSteps.UpdateOrderById(orderId, token, orderUpdateModel);

//            OrderAllInfoResponseModel expectedOrder = new OrderAllInfoResponseModel()
//            {
//                Id = orderId,
//                ClienId = clientId,
//                SitterId = sitterId,
//                Type = orderModel.Type,
//                Status = 1,
//                Price = sitterModel.PriceCatalog[1].Price,
//                Date = orderUpdateModel.Date,
//                Address = orderUpdateModel.Address,
//                Animals = new List<AnimalAllInfoResponseModel>()
//                {
//                    expectedAnimal,
//                },
//                Comments = null,
//                IsDeleted = false,
//            };
//            _clientSteps.GetAllInfoOrderById(orderId, token, expectedOrder);
//        }

//        public void EditingServicesWalking_WhenAddingAnimalAndOrderModelIsCorrect_ShouldEditingServicesWalking()
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

//            AnimalRegistrationRequestModel animalTwoModel = new AnimalRegistrationRequestModel()
//            {
//                Name = "Мистер главный",
//                Age = 2,
//                RecommendationsForCare = "Мыть лапы тщательно",
//                Breed = "Доберман",
//                Size = 7,
//                ClientId = clientId,
//            };
//            int animalTwoId = _clientSteps.RegisterAnimalToClientProfile(animalTwoModel);
//            AnimalAllInfoResponseModel expectedTwoAnimal = new AnimalAllInfoResponseModel()
//            {
//                Id = animalTwoId,
//                Name = animalTwoModel.Name,
//                Age = animalTwoModel.Age,
//                RecommendationsForCare = animalTwoModel.RecommendationsForCare,
//                Breed = animalTwoModel.Breed,
//                Size = animalTwoModel.Size,
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

//            OrderUpdateRequestModel orderUpdateModel = new OrderUpdateRequestModel()
//            {
//                Address = orderModel.Address,
//                Date = orderModel.Date,
//                Animals = new List<AnimalUpdateRequestModel>()
//                {
//                    new AnimalUpdateRequestModel()
//                    {
//                        Name = animalModel.Name,
//                        Age = animalModel.Age,
//                        RecommendationsForCare = animalModel.RecommendationsForCare,
//                        Breed = animalModel.Breed,
//                        Size = animalModel.Size,
//                    },
//                    new AnimalUpdateRequestModel()
//                    {
//                        Name = animalTwoModel.Name,
//                        Age = animalTwoModel.Age,
//                        RecommendationsForCare = animalTwoModel.RecommendationsForCare,
//                        Breed = animalTwoModel.Breed,
//                        Size = animalTwoModel.Size,
//                    },
//                },
//            };

//            OrderAllInfoResponseModel expectedOrder = new OrderAllInfoResponseModel()
//            {
//                Id = orderId,
//                ClienId = clientId,
//                SitterId = sitterId,
//                Type = orderModel.Type,
//                Status = 1,
//                Price = sitterModel.PriceCatalog[1].Price,
//                Date = orderUpdateModel.Date,
//                Address = orderUpdateModel.Address,
//                Animals = new List<AnimalAllInfoResponseModel>()
//                {
//                    expectedAnimal,
//                    expectedTwoAnimal,
//                },
//                Comments = null,
//                IsDeleted = false,
//            };
//            _clientSteps.GetAllInfoOrderById(orderId, token, expectedOrder);
//        }

//        public void DeleteServicesWalking_WhenOrderIdIsCorrect_ShouldDeleteServicesWalking()
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

//            _clientSteps.DeleteOrderById(orderId, token);

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
//                Comments = null,
//                IsDeleted = true,
//            };
//            _clientSteps.GetAllInfoOrderById(orderId, token, expectedOrder);
//        }
//    }
//}
