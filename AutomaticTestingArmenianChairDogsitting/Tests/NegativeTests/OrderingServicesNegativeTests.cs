using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using System.Collections.Generic;
using System;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTests
{
    public class OrderingServicesNegativeTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private ClientNegativeSteps _clientNegativeSteps;
        private SitterSteps _sitterSteps;
        private SitterNegativeSteps _sitterNegativeSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private string _clientToken;
        private string _alienClientToken;
        private string _sitterToken;
        private int _clientId;
        private int _alienClientId;
        private int _sitterId;
        private int _alienSitterId;
        private int _animalId;
        private int _alienAnimalId;
        private int _orderId;
        private int _alienOrderId;
        private ClientRegistrationRequestModel _clientModel;
        private ClientRegistrationRequestModel _alienClientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private SitterRegistrationRequestModel _alienSitterModel;
        private AnimalRegistrationRequestModel _animalModel;
        private AnimalRegistrationRequestModel _alienAnimalModel;
        private DateTime _date = DateTime.Now;

        public OrderingServicesNegativeTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _clientNegativeSteps = new ClientNegativeSteps();
            _sitterSteps = new SitterSteps();
            _sitterNegativeSteps = new SitterNegativeSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
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
                Name = "Валера",
                LastName = "Валерич",
                Email = "valera@gmail.com",
                Phone = "+79514147895",
                Address = "ул. Прямая, дом. 1",
                Password = "12234567",
                Promocode = ""
            };
            _alienClientId = _clientSteps.RegisterClientTest(_alienClientModel);
            AuthRequestModel authAlienClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_alienClientModel);
            _alienClientToken = _authorization.AuthorizeTest(authAlienClientModel);
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
                    new PriceCatalogRequestModel() { Service = 1, Price = 5000 },
                    new PriceCatalogRequestModel() { Service = 2, Price = 3000 },
                    new PriceCatalogRequestModel() { Service = 4, Price = 500 },
                }

            };
            _sitterId = _sitterSteps.RegisterSitterTest(_sitterModel);
            AuthRequestModel authSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_sitterModel);
            _sitterToken = _authorization.AuthorizeTest(authSitterModel);
            _alienSitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Дима",
                LastName = "Васюкин",
                Phone = "+79511475511",
                Email = "vas@gmail.com",
                Password = "11122458",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 3, Price = 850 },
                    new PriceCatalogRequestModel() { Service = 4, Price = 650 },
                }
            };
            _alienSitterId = _sitterSteps.RegisterSitterTest(_alienSitterModel);
            _animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Бука",
                Age = 2,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _clientId,
            };
            _animalId = _clientSteps.RegisterAnimalToClientProfileTest(_animalModel, _clientToken);
            _alienAnimalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Saw",
                Age = 7,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _alienClientId,
            };
            _alienAnimalId = _clientSteps.RegisterAnimalToClientProfileTest(_alienAnimalModel, _alienClientToken);
            OrderWalkRegistrationRequestModel orderWalkModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = _date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[2].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            _orderId = _clientSteps.RegisterOrderWalkTest(orderWalkModel, _clientToken);
            OrderWalkRegistrationRequestModel alienOrderWalkModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _alienClientId,
                SitterId = _sitterId,
                WorkDate = _date,
                Address = _alienClientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[2].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _alienAnimalId,
                }
            };
            _alienOrderId = _clientSteps.RegisterOrderWalkTest(alienOrderWalkModel, _alienClientToken);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        //Client
        [Test]
        public void OrderingServicesNegativeTest_WhenTwoServicesForSameDog_ShouldGetHttpStatusCodeBadRequest()
        {           
            OrderWalkRegistrationRequestModel orderWalkModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _alienSitterId,
                WorkDate = _date,
                Address = _clientModel.Address,
                District = 2,
                Type = _alienSitterModel.PriceCatalog[1].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            OrderOverexposeRegistrationRequestModel orderOverexposeModel = new OrderOverexposeRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = _date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[1].Service,
                DayQuantity = 2,
                WalkPerDayQuantity = 2,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            _clientNegativeSteps.OrderingServicesWhenTwoServicesForSameDogNegativeTest(orderWalkModel, orderOverexposeModel, _clientToken);
        }

        [Test]
        public void OrderingServicesNegativeTest_WhenPastOrderServiceDateAndTime_ShouldGetHttpStatusCodeUnprocessableEntity()
        {
            var pastDate = DateTime.Now;
            pastDate = pastDate.AddDays(-1);
            var pastTime = DateTime.Now;
            pastTime = pastTime.AddHours(-2);
            OrderWalkRegistrationRequestModel orderWalkModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = pastDate,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[2].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            OrderWalkRegistrationRequestModel twoOrderWalkModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = pastTime,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[2].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            _clientNegativeSteps.OrderingServicesWhenPastOrderServiceDateAndTimeNegativeTest(orderWalkModel, _clientToken);
            _clientNegativeSteps.OrderingServicesWhenPastOrderServiceDateAndTimeNegativeTest(twoOrderWalkModel, _clientToken);
        }

        //Sitter
        [Test]
        public void PerformServiceNegativeTest_ForDifferentClientsSimultaneously_ShouldGetHttpStatusCodeBadRequest()
        {
            var ststus = 2;
            _sitterSteps.UpdateOrderStatusByOrderIdTest(_orderId, ststus, _sitterToken);
            _sitterNegativeSteps.PerformServiceForDifferentClientsSimultaneouslyNegativeTest(_alienOrderId, ststus, _sitterToken);
        }
    }
}
