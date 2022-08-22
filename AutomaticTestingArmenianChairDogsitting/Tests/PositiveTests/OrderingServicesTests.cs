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
        private string _alienClientToken;
        private string _sitterToken;
        private int _clientId;
        private int _alienClientId;
        private int _sitterId;
        private int _animalId;
        private int _alienAnimalId;
        private List<ClientsAnimalsResponseModel> _animals;
        private List<ClientsAnimalsResponseModel> _alienAnimals;
        private ClientRegistrationRequestModel _clientModel;
        private ClientRegistrationRequestModel _alienClientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private AnimalRegistrationRequestModel _animalModel;
        private AnimalRegistrationRequestModel _alienAnimalModel;

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
            _alienAnimals = new List<ClientsAnimalsResponseModel>();
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
            _alienClientModel = new ClientRegistrationRequestModel()
            {
                Name = "Саша",
                LastName = "Ким",
                Email = "kim@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "11345678",
                Promocode = "ADF8FGEL"
            };
            _alienClientId = _clientSteps.RegisterClientTest(_alienClientModel);
            AuthRequestModel authAlienClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _alienClientToken = _authorization.AuthorizeTest(authAlienClientModel);
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
            _animalId = _clientSteps.RegisterAnimalToClientProfileTest(_animalModel, _clientToken);
            _alienAnimalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Люцифер",
                Age = 5,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _alienClientId,
            };
            _alienAnimalId = _clientSteps.RegisterAnimalToClientProfileTest(_alienAnimalModel, _alienClientToken);
            _animals.Add(_animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(_animalId, _animalModel));
            _alienAnimals.Add(_animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(_alienAnimalId, _alienAnimalModel));
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [Test]
        public void OrderingServiceTrialWalk_WhenOrderModelIsCorrectAnd_ShouldOrderingServiceTrialWalk()
        {
            var date = DateTime.Now;
            var priceTrialWalk = 0;
            OrderWalkRegistrationRequestModel orderModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _alienClientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _alienClientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[3].Service,
                IsTrial = true,
                AnimalIds = new List<int>()
                {
                    _alienAnimalId,
                }
            };
            var orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _alienClientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, priceTrialWalk, _alienAnimals, orderModel, orderModel.Status);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _alienClientToken, expectedOrder);
            _clientSteps.FindAddedOrderInClientTest(_alienClientId, _alienClientToken, expectedOrder);
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
            var orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, _sitterModel.PriceCatalog[3].Price, _animals, orderModel, orderModel.Status);
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
            var orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            orderUpdateCaseModel.AnimalIds = new List<int>()
            {
                 _animalId,
            };
            _clientSteps.UpdateOrderWalkByIdTest(orderId, orderUpdateCaseModel, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkUpdateRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, _sitterModel.PriceCatalog[3].Price, _animals, orderUpdateCaseModel, orderModel.Status, orderModel.Type);
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
            var orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            animalCaseModel.ClientId = _clientId;
            var animalCaseId = _clientSteps.RegisterAnimalToClientProfileTest(animalCaseModel, _clientToken);
            OrderWalkUpdateRequestModel orderUpdateModel = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderWalkUpdateRequestModel
                (orderModel.WorkDate, orderModel);
            orderUpdateModel.AnimalIds.Add(animalCaseId);
            _clientSteps.UpdateOrderWalkByIdTest(orderId, orderUpdateModel, _clientToken);
            ClientsAnimalsResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel
                (animalCaseId, animalCaseModel);
            _clientSteps.FindAddedAnimalInOrderTest(orderId, _clientToken, expectedAnimal);
            _animals.Add(expectedAnimal);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkUpdateRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, _sitterModel.PriceCatalog[3].Price, _animals, orderUpdateModel, orderModel.Status, orderModel.Type);
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
            var orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            _clientSteps.DeleteOrderByIdTest(orderId, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, _sitterModel.PriceCatalog[3].Price, _animals, orderModel, orderModel.Status);
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
            var orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            _sitterSteps.UpdateOrderStatusByOrderIdTest(orderId, status, _sitterToken);
            _clientSteps.DeleteOrderByIdTest(orderId, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, _sitterModel.PriceCatalog[3].Price, _animals, orderModel, status);
            expectedOrder.IsDeleted = true;
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
            _clientSteps.FindDeletedOrderInClientTest(_clientId, _clientToken, expectedOrder);
        }

        [Test]
        public void ChangeStatusServiceWalkBySitter_WhenStatusIsCorrectAndStatus_ShouldChangeStatusServiceWalkInProcess()
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
            var orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            _sitterSteps.UpdateOrderStatusByOrderIdTest(orderId, status, _sitterToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, _sitterModel.PriceCatalog[3].Price, _animals, orderModel, status);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(EditingServiceOverexpose_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource))]
        public void EditingServiceOverexpose_WhenChangeOrdersDataAndOrderModelIsCorrect_ShouldEditingOrdersDataToServiceOverexpose
            (OrderOverexposeUpdateRequestModel orderUpdateCaseModel)
        {
            var date = DateTime.Now;
            decimal price;
            OrderOverexposeRegistrationRequestModel orderModel = new OrderOverexposeRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[1].Service,
                DayQuantity = 1,
                WalkPerDayQuantity = 2,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            var orderId = _clientSteps.RegisterOrderOverexposeTest(orderModel, _clientToken);
            orderUpdateCaseModel.AnimalIds = new List<int>()
            {
                 _animalId,
            };
            _clientSteps.UpdateOrderOverexposeByIdTest(orderId, orderUpdateCaseModel, _clientToken);
            price = ((_sitterModel.PriceCatalog[1].Price * orderUpdateCaseModel.DayQuantity)
                + (_sitterModel.PriceCatalog[3].Price * orderUpdateCaseModel.WalkPerDayQuantity));
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderOverexposeUpdateRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, price, _animals, orderUpdateCaseModel, orderModel.Status, orderModel.Type);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(EditingServiceDailySitting_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource))]
        public void EditingServiceDailySitting_WhenChangeOrdersDataAndOrderModelIsCorrect_ShouldEditingOrdersDataToServiceDailySitting
            (OrderDailySittingUpdateRequestModel orderUpdateCaseModel)
        {
            var date = DateTime.Now;
            decimal price;
            OrderDailySittingRegistrationRequestModel orderModel = new OrderDailySittingRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[0].Service,
                DayQuantity = 1,
                WalkPerDayQuantity = 2,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            var orderId = _clientSteps.RegisterOrderDailySittingTest(orderModel, _clientToken);
            orderUpdateCaseModel.AnimalIds = new List<int>()
            {
                 _animalId,
            };
            _clientSteps.UpdateOrderDailySittingByIdTest(orderId, orderUpdateCaseModel, _clientToken);
            price = ((_sitterModel.PriceCatalog[0].Price * orderUpdateCaseModel.DayQuantity)
                + (_sitterModel.PriceCatalog[3].Price * orderUpdateCaseModel.WalkPerDayQuantity));
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderDailySittingUpdateRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, price, _animals, orderUpdateCaseModel, orderModel.Status, orderModel.Type);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
        }

        [TestCaseSource(typeof(EditingServiceSittingForADay_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource))]
        public void EditingServiceSittingForADay_WhenChangeOrdersDataAndOrderModelIsCorrect_ShouldEditingOrdersDataToServiceSittingForADay
            (OrderSittingForADayUpdateRequestModel orderUpdateCaseModel)
        {
            var date = DateTime.Now;
            decimal price;
            OrderSittingForADayRegistrationRequestModel orderModel = new OrderSittingForADayRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[2].Service,
                VisitQuantity = 2,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            var orderId = _clientSteps.RegisterOrderSittingForADayTest(orderModel, _clientToken);
            orderUpdateCaseModel.AnimalIds = new List<int>()
            {
                 _animalId,
            };
            _clientSteps.UpdateOrderSittingForADayByIdTest(orderId, orderUpdateCaseModel, _clientToken);
            price = _sitterModel.PriceCatalog[2].Price * orderUpdateCaseModel.VisitQuantity;
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderSittingForADayUpdateRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, price, _animals, orderUpdateCaseModel, orderModel.Status, orderModel.Type);
            _clientSteps.GetAllInfoOrderByIdTest(orderId, _clientToken, expectedOrder);
        }
    }
}
