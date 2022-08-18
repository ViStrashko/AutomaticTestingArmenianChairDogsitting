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
                Phone = "+79514125547",
                Email = "pet@gmail.com",
                Password = "87654321",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
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

        [TestCaseSource(typeof(OrderingService_WhenOrderModelIsCorrect_TestSource))]
        public void OrderingService_WhenOrderModelIsCorrect_ShouldOrderingService(PriceCatalogResponseModel priceCatalog)
        {
            var date = DateTime.Now;
            var dateUpdated = DateTime.Now;
            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                Type = priceCatalog.Service,
                WorkDate = date,
                Address = _clientModel.Address,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(orderModel, _clientToken);

            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, date, dateUpdated, priceCatalog.Price, _animals, orderModel);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);

            _clientSteps.FindAddedOrderInClientTest(_clientId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(EditingService_WhenChangeOrdersAddressAndOrderModelIsCorrect_TestSource))]
        public void EditingService_WhenChangeAddressAndOrderModelIsCorrect_ShouldEditingOrdersAddressToService
            (PriceCatalogResponseModel priceCatalog, OrderUpdateRequestModel orderUpdateCaseModel)
        {
            var date = DateTime.Now;
            var dateUpdated = DateTime.Now;
            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                Type = priceCatalog.Service,
                WorkDate = date,
                Address = _clientModel.Address,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(orderModel, _clientToken);

            OrderUpdateRequestModel orderUpdateModel = _orderMappers.MappOrderRegistrationRequestModelToOrderUpdateRequestModel
                (date, orderModel);
            orderUpdateModel.Address = orderUpdateCaseModel.Address;
            _clientSteps.UpdateOrderByIdTest(orderId, orderUpdateModel, _clientToken);

            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, date, dateUpdated, priceCatalog.Price, _animals, orderModel);
            expectedOrder.Address = orderUpdateCaseModel.Address;
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(EditingService_WhenChangeOrdersDateAndOrderModelIsCorrect_TestSource))]
        public void EditingService_WhenChangeDateAndOrderModelIsCorrect_ShouldEditingOrdersDateToService
            (PriceCatalogResponseModel priceCatalog, OrderUpdateRequestModel orderUpdateCaseModel)
        {
            var date = DateTime.Now;
            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                Type = priceCatalog.Service,
                WorkDate = date,
                Address = _clientModel.Address,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(orderModel, _clientToken);

            OrderUpdateRequestModel orderUpdateModel = _orderMappers.MappOrderRegistrationRequestModelToOrderUpdateRequestModel
                (orderUpdateCaseModel.WorkDate, orderModel);
            _clientSteps.UpdateOrderByIdTest(orderId, orderUpdateModel, _clientToken);

            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, date, orderUpdateCaseModel.WorkDate, priceCatalog.Price, _animals, orderModel);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(EditingService_WhenAnimalModelIsCorrectAndOrderModelIsCorrect_TestSource))]
        public void EditingService_WhenAnimalModelIsCorrectAndOrderModelIsCorrect_ShouldAddingAnimalToService
            (PriceCatalogResponseModel priceCatalog, AnimalRegistrationRequestModel animalCaseModel)
        {
            var date = DateTime.Now;
            animalCaseModel.ClientId = _clientId;
            int animalCaseId = _clientSteps.RegisterAnimalToClientProfileTest(animalCaseModel, _clientToken);

            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                Type = priceCatalog.Service,
                WorkDate = date,
                Address = _clientModel.Address,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(orderModel, _clientToken);

            OrderUpdateRequestModel orderUpdateModel = _orderMappers.MappOrderRegistrationRequestModelToOrderUpdateRequestModel
                (date, orderModel);
            orderUpdateModel.AnimalIds.Add(animalCaseId);
            _clientSteps.UpdateOrderByIdTest(orderId, orderUpdateModel, _clientToken);

            ClientsAnimalsResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel
                (animalCaseId, animalCaseModel);
            _clientSteps.FindAddedAnimalInOrderTest(orderId, _clientToken, expectedAnimal);
        }

        [TestCaseSource(typeof(EditingService_WhenAnimalIdIsCorrectAndOrderModelIsCorrect_TestSource))]
        public void EditingService_WhenAnimalIdIsCorrectAndOrderModelIsCorrect_ShouldDeletedAnimalFromService
            (PriceCatalogResponseModel priceCatalog)
        {
            var date = DateTime.Now;
            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                Type = priceCatalog.Service,
                WorkDate = date,
                Address = _clientModel.Address,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(orderModel, _clientToken);

            OrderUpdateRequestModel orderUpdateModel = _orderMappers.MappOrderRegistrationRequestModelToOrderUpdateRequestModel
                (date, orderModel);
            orderUpdateModel.AnimalIds.Remove(_animalId);
            _clientSteps.UpdateOrderByIdTest(orderId, orderUpdateModel, _clientToken);

            ClientsAnimalsResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel
                (_animalId, _animalModel);
            _clientSteps.FindDeletedAnimalInOrderTest(orderId, _clientToken, expectedAnimal);
        }

        [TestCaseSource(typeof(DeleteService_WhenOrderIdIsCorrect_TestSource))]
        public void DeleteService_WhenOrderIdIsCorrectAndStatusCreated_ShouldDeleteService(PriceCatalogResponseModel priceCatalog)
        {
            var date = DateTime.Now;
            var dateUpdated = DateTime.Now;
            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                Type = priceCatalog.Service,
                WorkDate = date,
                Address = _clientModel.Address,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(orderModel, _clientToken);

            _clientSteps.DeleteOrderByIdTest(orderId, _clientToken);

            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, date, dateUpdated, priceCatalog.Price, _animals, orderModel);
            expectedOrder.IsDeleted = true;
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);

            _clientSteps.FindDeletedOrderInClientTest(_clientId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(DeleteService_WhenOrderIdIsCorrect_TestSource))]
        public void DeleteService_WhenOrderIdIsCorrectAndStatusInProcess_ShouldDeleteService(PriceCatalogResponseModel priceCatalog)
        {
            var date = DateTime.Now;
            var dateUpdated = DateTime.Now;
            var status = 2;
            OrderRegistrationRequestModel orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                Type = priceCatalog.Service,
                WorkDate = date,
                Address = _clientModel.Address,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            int orderId = _clientSteps.RegisterOrderTest(orderModel, _clientToken);

            _clientSteps.DeleteOrderByIdTest(orderId, _clientToken);

            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, date, dateUpdated, priceCatalog.Price, _animals, orderModel, status);
            expectedOrder.IsDeleted = true;
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);

            _clientSteps.FindDeletedOrderInClientTest(_clientId, _clientToken, expectedOrder);
        }
    }
}
