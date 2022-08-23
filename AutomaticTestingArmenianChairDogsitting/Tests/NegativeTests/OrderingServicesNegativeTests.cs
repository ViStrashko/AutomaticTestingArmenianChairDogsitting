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
        private ClientMappers _clientMappers;
        private SitterMappers _sitterMappers;
        private AnimalMappers _animalMappers;
        private string _adminToken;
        private string _clientToken;
        private string _sitterToken;
        private string _alienSitterToken;
        private int _clientId;
        private int _sitterId;
        private int _alienSitterId;
        private int _animalId;
        private ClientRegistrationRequestModel _clientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private SitterRegistrationRequestModel _alienSitterModel;
        private AnimalRegistrationRequestModel _animalModel;
        DateTime date = DateTime.Now;;

        public OrderingServicesNegativeTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _clientNegativeSteps = new ClientNegativeSteps();
            _sitterSteps = new SitterSteps();
            _sitterNegativeSteps = new SitterNegativeSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _clientMappers = new ClientMappers();
            _sitterMappers = new SitterMappers();
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
            _adminToken = _authorization.AuthorizeTest(new AuthRequestModel()
            { Email = Options.adminEmail, Password = Options.adminPassword });
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
            AuthRequestModel authAlienSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_alienSitterModel);
            _alienSitterToken = _authorization.AuthorizeTest(authAlienSitterModel);
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
            OrderOverexposeRegistrationRequestModel orderOverexposeModel = new OrderOverexposeRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
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
            _clientSteps.RegisterOrderOverexposeTest(orderOverexposeModel, _clientToken);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        //Client
        [Test]
        public void OrderingServicesNegativeTest_WhenTwoServicesForSameDog_ShouldGetHttpStatusCodeBadRequest
            (ClientUpdateRequestModel clientUpdateModel)
        {
            OrderWalkRegistrationRequestModel orderWalkModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
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
                SitterId = _alienSitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[1].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            _clientNegativeSteps.OrderingServicesWhenTwoServicesForSameDogNegativeTest(orderWalkModel, _clientToken);
            _clientNegativeSteps.OrderingServicesWhenTwoServicesForSameDogNegativeTest(twoOrderWalkModel, _clientToken);
        }
    }
}
