using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ClientTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class EditingAProfileTests
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
        private ClientRegistrationRequestModel _clientModel;

        public EditingAProfileTests()
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
            _clientId = _clientSteps.RegisterClient(_clientModel);

            AuthRequestModel authModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _token = _authorization.Authorize(authModel);
        }
        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(EditingClientProfile_WhenClientModelIsCorrect_TestSource))]
        public void EditingClientProfile_WhenClientModelIsCorrect_ShouldEditingClientProfile(ClientUpdateRequestModel clientUpdateModel)
        {
            _clientSteps.UpdateClientById(_clientId, _token, clientUpdateModel);
            var date = DateTime.Now.Date;

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientUpdateRequestModelToClientAllInfoResponseModel(clientUpdateModel, _clientId, date);
            _clientSteps.GetAllInfoClientById(_clientId, _token, expectedClient);
        }

        [Test]
        public void DeleteClientProfile_WhenClientIdIsCorrect_ShouldDeletingClientProfile()
        {
            _clientSteps.DeleteClientById(_clientId, _token);
            var date = DateTime.Now.Date;

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientRegistrationRequestModelToClientAllInfoResponseModel(_clientModel, _clientId, date);
            expectedClient.IsDeleted = true;
            _clientSteps.GetAllInfoClientById(_clientId, _token, expectedClient);
        }
                
        [Test]
        public void EditingSitterProfile_WhenSitterModelIsCorrect_ShouldEditingSitterProfile()
        {
            SitterRegistrationRequestModel sitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Email = "pet@gmail.com",
                Age = 20,
                Description = "Description",
                Experience = 10,
                Sex = 1,
                Phone = "+79514125547",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Service = 1,
                        Price = 500,
                    },
                },
                Password = "12345678",

            };
            int sitterId = _sitterSteps.RegisterSitter(sitterModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = sitterModel.Email,
                Password = sitterModel.Password,
            };
            string token = _authorization.Authorize(authModel);

            SitterUpdateRequestModel sitterUpdateModel = new SitterUpdateRequestModel()
            {
                Name = sitterModel.Name,
                LastName = sitterModel.LastName,
                Email = sitterModel.Email,
                Age = sitterModel.Age,
                Sex = sitterModel.Sex,
                Experience = sitterModel.Experience,
                Description = sitterModel.Description,
                Phone = "+79518741247",
                PriceCatalog = new List<PriceCatalogUpdateRequestModel>()
                {
                    new PriceCatalogUpdateRequestModel()
                    {
                        Service = sitterModel.PriceCatalog[1].Service,
                        Price =  sitterModel.PriceCatalog[1].Price,
                    },
                },
            };
            _sitterSteps.UpdateSitterById(sitterId, token, sitterUpdateModel);

            SitterAllInfoResponseModel expectedSitter = new SitterAllInfoResponseModel()
            {
                Id = sitterId,
                Name = sitterUpdateModel.Name,
                LastName = sitterUpdateModel.LastName,
                Phone = sitterUpdateModel.Phone,
                Email = sitterUpdateModel.Email,
                Age= sitterUpdateModel.Age,
                Description = sitterUpdateModel.Description,
                Sex = sitterUpdateModel.Sex,
                Experience= sitterUpdateModel.Experience,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        SitterId = sitterId,
                        Service = sitterUpdateModel.PriceCatalog[1].Service,
                        Price =  sitterUpdateModel.PriceCatalog[1].Price,
                        IsDeleted = false,
                    },
                },
                IsDeleted  = false,
            };
            _sitterSteps.GetAllInfoSitterById(sitterId, token, expectedSitter);
        }

        [Test]
        public void DeleteSitterProfile_WhenSitterIdIsCorrect_ShouldDeletingSitterProfile()
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
                Password = "12345678"
            };
            int sitterId = _sitterSteps.RegisterSitter(sitterModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = sitterModel.Email,
                Password = sitterModel.Password,
            };
            string token = _authorization.Authorize(authModel);

            _sitterSteps.DeleteSitterById(sitterId, token);

            SitterAllInfoResponseModel expectedSitter = new SitterAllInfoResponseModel()
            {
                Id = sitterId,
                Name = sitterModel.Name,
                LastName = sitterModel.LastName,
                Email = sitterModel.Email,
                Phone = sitterModel.Phone,
                Age = sitterModel.Age,
                Description = sitterModel.Description,
                Experience= sitterModel.Experience,
                Sex= sitterModel.Sex,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        SitterId = sitterId,
                        Service = sitterModel.PriceCatalog[1].Service,
                        Price =  sitterModel.PriceCatalog[1].Price,
                        IsDeleted = false,
                    },
                },
                IsDeleted = true,
            };
            _sitterSteps.GetAllInfoSitterById(sitterId, token, expectedSitter);
        }
    }
}
