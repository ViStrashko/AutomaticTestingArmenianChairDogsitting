using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSourses.ClientTestSourses;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class RegistrationTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private ClientMappers _clientMappers;
        private string _token;
        private int _clientId;
        private int _sitterId;

        public RegistrationTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _clientMappers = new ClientMappers();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.AfterScenario();
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.AfterScenario();
        }

        [TestCaseSource(typeof(ClientCreation_WhenClientModelIsCorrect_TetsSours))]
        public void ClientCreation_WhenClientModelIsCorrect_ShouldCreateClient(ClientRegistrationRequestModel clientModel)
        {
            _clientId = _clientSteps.RegisterClient(clientModel);

            AuthRequestModel authModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(clientModel);
            _token = _authorization.Authorize(authModel);

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientRegistrationRequestModelToClientAllInfoResponseModel(clientModel, _clientId);
            _clientSteps.GetAllInfoClientById(_clientId, _token, expectedClient);
        }

        [Test]
        public void SitterCreation_WhenSitterModelIsCorrect_ShouldCreateSitter()
        {
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
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Service = 1,
                        Price = 500,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 2,
                        Price = 700,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 3,
                        Price = 1000,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 4,
                        Price = 1500,
                    },
                },
                Password = "12345678",
            };
            _sitterId = _sitterSteps.RegisterSitter(sitterModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = sitterModel.Email,
                Password = sitterModel.Password,
            };
            _token = _authorization.Authorize(authModel);

            SitterAllInfoResponseModel expectedSitter = new SitterAllInfoResponseModel()
            {
                Id = _sitterId,
                Name = sitterModel.Name,
                LastName = sitterModel.LastName,
                Phone = sitterModel.Phone,
                Email = sitterModel.Email,
                Age = sitterModel.Age,
                Description = sitterModel.Description,
                Experience = sitterModel.Experience,
                Sex = sitterModel.Sex,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel.PriceCatalog[1].Service,
                        Price = sitterModel.PriceCatalog[1].Price,
                        SitterId = _sitterId,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel.PriceCatalog[2].Service,
                        Price = sitterModel.PriceCatalog[2].Price,
                        SitterId = _sitterId,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel.PriceCatalog[3].Service,
                        Price = sitterModel.PriceCatalog[3].Price,
                        SitterId = _sitterId,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel.PriceCatalog[4].Service,
                        Price = sitterModel.PriceCatalog[4].Price,
                        SitterId = _sitterId,
                        IsDeleted = false,
                    },
                },
                IsDeleted = false,
            };
            _sitterSteps.GetAllInfoSitterById(_sitterId, _token, expectedSitter);
        }
    }
}
