using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class OrderingServicesTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private OrderMappers _orderMappers;
        private AnimalMappers _animalMappers;
        private string _clientToken;
        private string _sitterToken;
        private int _clientId;
        private int _sitterId;
        private int _animalId;
        private ClientRegistrationRequestModel _clientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private AnimalRegistrationRequestModel _animalModel;

        public OrderingServicesTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _orderMappers = new OrderMappers();
            _animalMappers = new AnimalMappers();
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

            AuthRequestModel authClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _clientToken = _authorization.AuthorizeTest(authClientModel);

            _sitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet@gmail.com",
                Password = "87654321",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
            };
            _sitterId = _sitterSteps.RegisterSitterTest(_sitterModel);

            AuthRequestModel authSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_sitterModel);
            _sitterToken = _authorization.AuthorizeTest(authSitterModel);

            _animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _clientId,
            };
            _animalId = _clientSteps.RegisterAnimalToClientProfileTest(_clientToken, _animalModel);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(OrderingService_WhenOrderModelIsCorrect_TestSource))]
        public void OrderingService_WhenOrderModelIsCorrect_ShouldOrderingService(PriceCatalogResponseModel priceCatalog)
        {
            var date = DateTime.Now;
            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                Type = priceCatalog.Service,
                Date = date,
                Address = _clientModel.Address,
                Animals = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(_clientToken, orderModel);

            ClientsAnimalsResponseModel animal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(_animalModel, _animalId);
            List<ClientsAnimalsResponseModel> animals = new List<ClientsAnimalsResponseModel>();
            animals.Add(animal);

            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderRegistrationRequestModelToOrderAllInfoResponseModel
                (orderModel, orderId, date, priceCatalog.Price, animals);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
        }

        [Test]
        public void EditingService_WhenChangeAddressAndOrderModelIsCorrect_ShouldEditingServicesAddressToService()
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

        public void EditingService_WhenAddingAnimalToServiceAndOrderModelIsCorrect_ShouldAddingAnimalToService()
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

        public void DeleteService_WhenOrderIdIsCorrect_ShouldDeleteService()
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
