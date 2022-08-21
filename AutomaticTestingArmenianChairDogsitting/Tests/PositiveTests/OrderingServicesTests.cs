using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
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
        private int _clientId;
        private int _sitterId;
        private int _animalId;
        private List<ClientsAnimalsResponseModel> _animals;
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
            _animals = new List<ClientsAnimalsResponseModel>();
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
                Promocode = ""
            };
            _clientId = _clientSteps.RegisterClientTest(_clientModel);
            AuthRequestModel authClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _clientToken = _authorization.AuthorizeTest(authClientModel);
            _sitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Phone = "89514125547",
                Email = "pet@gmail.com",
                Password = "87654321",
                Age = 20,
                Experience = 4,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 5000 },
                    new PriceCatalogRequestModel() { Service = 2, Price = 4000 },
                    new PriceCatalogRequestModel() { Service = 3, Price = 800 },
                    new PriceCatalogRequestModel() { Service = 4, Price = 500 }
                }
            };
            _sitterId = _sitterSteps.RegisterSitterTest(_sitterModel);
            AuthRequestModel authSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_sitterModel);
            _authorization.AuthorizeTest(authSitterModel);
            _animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _clientId,
            };
            _animalId = _clientSteps.RegisterAnimalToClientProfileTest(_animalModel, _clientToken);
            _animals.Add(_animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(_animalId, _animalModel));
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [Test]
        public void OrderingServiceWalk_WhenOrderModelIsCorrect_ShouldOrderingServiceWalk()
        {
            var date = DateTime.Now;
            OrderWalkRegistrationRequestModel orderModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[3].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, date, _sitterModel.PriceCatalog[3].Price, _animals, orderModel, orderModel.Status);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
            _clientSteps.FindAddedOrderInClientTest(_clientId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(EditingServiceWalk_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource))]
        public void EditingServiceWalk_WhenChangeOrdersDataAndOrderModelIsCorrect_ShouldEditingOrdersDataToServiceWalk
            (OrderWalkUpdateRequestModel orderUpdateCaseModel)
        {
            var date = DateTime.Now;
            OrderWalkRegistrationRequestModel orderModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[3].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            
            orderUpdateCaseModel.AnimalIds = new List<int>()
            {
                 _animalId,
            };
            _clientSteps.UpdateOrderWalkByIdTest(orderId, orderUpdateCaseModel, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkUpdateRequestModelToOrderAllInfoResponseModel
                (orderId, date, _sitterModel.PriceCatalog[3].Price, _animals, orderUpdateCaseModel, orderModel.Status,
                _sitterModel.PriceCatalog[3].Service);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(EditingServiceWalk_WhenAnimalModelIsCorrectAndOrderModelIsCorrect_TestSource))]
        public void EditingServiceWalk_WhenAnimalModelIsCorrectAndOrderModelIsCorrect_ShouldAddingAnimalToServiceWalkAndDeleteAnimalFromServiceWalk
            (AnimalRegistrationRequestModel animalCaseModel)
        {
            var date = DateTime.Now;            
            OrderWalkRegistrationRequestModel orderModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[3].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,                    
                }
            };
            int orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            animalCaseModel.ClientId = _clientId;
            int animalCaseId = _clientSteps.RegisterAnimalToClientProfileTest(animalCaseModel, _clientToken);
            OrderWalkUpdateRequestModel orderUpdateModel = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderWalkUpdateRequestModel
                (date, orderModel);
            orderUpdateModel.AnimalIds.Add(animalCaseId);
            _clientSteps.UpdateOrderWalkByIdTest(orderId, orderUpdateModel, _clientToken);
            ClientsAnimalsResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel
                (animalCaseId, animalCaseModel);
            _clientSteps.FindAddedAnimalInOrderTest(orderId, _clientToken, expectedAnimal);
            _animals.Add(expectedAnimal);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkUpdateRequestModelToOrderAllInfoResponseModel
                (orderId, date, _sitterModel.PriceCatalog[3].Price, _animals, orderUpdateModel, orderModel.Status,
                _sitterModel.PriceCatalog[3].Service);
            OrderAllInfoResponseModel actualOrder = _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
            ClientsAnimalsResponseModel expectedDeleteAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel
               (_animalId, _animalModel);
            actualOrder.Animals.Remove(expectedDeleteAnimal);
            _clientSteps.FindDeletedAnimalInOrderTest(orderId, _clientToken, expectedDeleteAnimal);
        }

        [Test]
        public void DeleteServiceWalk_WhenOrderIdIsCorrectAndStatusCreated_ShouldDeleteServiceWalk()
        {
            var date = DateTime.Now;
            OrderWalkRegistrationRequestModel orderModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[3].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            _clientSteps.DeleteOrderByIdTest(orderId, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, date, _sitterModel.PriceCatalog[3].Price, _animals, orderModel, orderModel.Status);
            expectedOrder.IsDeleted = true;
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
            _clientSteps.FindDeletedOrderInClientTest(_clientId, _clientToken, expectedOrder);
        }

        [Test]
        public void DeleteServiceWalk_WhenOrderIdIsCorrectAndStatusInProcess_ShouldDeleteServiceWalk()
        {
            var date = DateTime.Now;
            var status = 2;
            OrderWalkRegistrationRequestModel orderModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[3].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            _clientSteps.DeleteOrderByIdTest(orderId, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, date, _sitterModel.PriceCatalog[3].Price, _animals, orderModel, status);
            expectedOrder.IsDeleted = true;
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
            _clientSteps.FindDeletedOrderInClientTest(_clientId, _clientToken, expectedOrder);
        }
    }
}
