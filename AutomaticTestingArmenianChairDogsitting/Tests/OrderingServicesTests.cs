using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class OrderingServicesTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private AnimalMappers _animalMappers;
        private string _token;
        private int _clientId;
        private ClientRegistrationRequestModel _clientModel;

        private SitterSteps _sitterSteps;

        public OrderingServicesTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _animalMappers = new AnimalMappers();
            _sitterSteps = new SitterSteps();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.ClearAllDB();
        }

        [SetUp]
        public void SetUp()
        {
            _clientModel = new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "12345678",
            };
            _clientId = _clientSteps.RegisterClientTest(_clientModel);

            AuthRequestModel authModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _token = _authorization.AuthorizeTest(authModel);
        }
        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }


        [Test]
        public void OrderingServicesWalking_WhenOrderModelIsCorrect_ShouldOrderingServicesWalking()
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
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(token, animalModel);
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
            int orderId = _clientSteps.RegisterOrderTest(token, orderModel);

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
                Comments = null,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoOrderByIdTest(orderId, token, expectedOrder);
        }

        [Test]
        public void EditingServicesWalking_WhenChangeAddressAndOrderModelIsCorrect_ShouldEditingServicesWalking()
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
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(token, animalModel);
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
            int orderId = _clientSteps.RegisterOrderTest(token, orderModel);

            OrderUpdateRequestModel orderUpdateModel = new OrderUpdateRequestModel()
            {
                Address = "Каменноостровский проспект, дом 10",
                Date = orderModel.Date,
                Animals = new List<int>()
                {
                    animalId
                },
            };
            _clientSteps.UpdateOrderByIdTest(orderId, token, orderUpdateModel);

            OrderAllInfoResponseModel expectedOrder = new OrderAllInfoResponseModel()
            {
                Id = orderId,
                ClienId = clientId,
                SitterId = sitterId,
                Type = orderModel.Type,
                Status = 1,
                Date = orderUpdateModel.Date,
                Address = orderUpdateModel.Address,
                Animals = new List<ClientsAnimalsResponseModel>()
                {
                    //expectedAnimal,
                },
                Comments = null,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoOrderByIdTest(orderId, token, expectedOrder);
        }

        public void EditingServicesWalking_WhenAddingAnimalAndOrderModelIsCorrect_ShouldEditingServicesWalking()
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
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(token, animalModel);
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

            AnimalRegistrationRequestModel animalTwoModel = new AnimalRegistrationRequestModel()
            {
                Name = "Мистер главный",
                Age = 2,
                RecommendationsForCare = "Мыть лапы тщательно",
                Breed = "Доберман",
                Size = 7,
                ClientId = clientId,
            };
            int animalTwoId = _clientSteps.RegisterAnimalToClientProfileTest(token, animalTwoModel);
            AnimalAllInfoResponseModel expectedTwoAnimal = new AnimalAllInfoResponseModel()
            {
                Id = animalTwoId,
                Name = animalTwoModel.Name,
                Age = animalTwoModel.Age,
                RecommendationsForCare = animalTwoModel.RecommendationsForCare,
                Breed = animalTwoModel.Breed,
                Size = animalTwoModel.Size,
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
            int orderId = _clientSteps.RegisterOrderTest(token, orderModel);

            OrderUpdateRequestModel orderUpdateModel = new OrderUpdateRequestModel()
            {
                Address = orderModel.Address,
                Date = orderModel.Date,
                Animals = new List<int>()
                {
                    animalId,
                    animalTwoId,
                },
            };

            OrderAllInfoResponseModel expectedOrder = new OrderAllInfoResponseModel()
            {
                Id = orderId,
                ClienId = clientId,
                SitterId = sitterId,
                Type = orderModel.Type,
                Status = 1,
                Date = orderUpdateModel.Date,
                Address = orderUpdateModel.Address,
                Animals = new List<ClientsAnimalsResponseModel>()
                {
                    //expectedAnimal,
                    //expectedTwoAnimal,
                },
                Comments = null,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoOrderByIdTest(orderId, token, expectedOrder);
        }

        public void DeleteServicesWalking_WhenOrderIdIsCorrect_ShouldDeleteServicesWalking()
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
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(token, animalModel);
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
            int orderId = _clientSteps.RegisterOrderTest(token, orderModel);

            _clientSteps.DeleteOrderByIdTest(orderId, token);

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
                Comments = null,
                IsDeleted = true,
            };
            _clientSteps.GetAllInfoOrderByIdTest(orderId, token, expectedOrder);
        }
    }
}
