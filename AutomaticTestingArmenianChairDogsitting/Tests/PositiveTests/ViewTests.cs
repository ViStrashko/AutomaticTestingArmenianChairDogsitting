using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ViewTestSources;
using System;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
{
    public class ViewTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private SitterMappers _sitterMappers;
        private AuthMappers _authMapper;
        private string _anonimToken;
        private string _adminToken;
        private string _clientToken;
        private string _sitterToken;
        private int _sitterId;
        private ClientRegistrationRequestModel _clientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private SitterAllInfoResponseModel _expectedSitter;
        private DateTime _date = DateTime.Now;

        public ViewTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearingTables = new ClearingTables();
            _sitterMappers = new SitterMappers();
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
            _adminToken = _authorization.AuthorizeTest(new AuthRequestModel { Email = Options.adminEmail, Password = Options.adminPassword });
            _anonimToken = null;
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
            _clientSteps.RegisterClientTest(_clientModel);
            AuthRequestModel authClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _clientToken = _authorization.AuthorizeTest(authClientModel);
            _sitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Дима",
                LastName = "Пет",
                Phone = "89514125547",
                Email = "pet@gmail.com",
                Password = "85554321",
                Age = 20,
                Experience = 2,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 5000 },
                }
            };
            _sitterId = _sitterSteps.RegisterSitterTest(_sitterModel);
            AuthRequestModel authSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_sitterModel);
            _sitterToken = _authorization.AuthorizeTest(authSitterModel);
            _expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(_sitterId, _date, _sitterModel);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(GetAllSittersByAnyRoleTestSource))]
        public void GetAllSittesTest_ByAllRoles_ShouldReturnAllSitters(List<SitterRegistrationRequestModel> sitters)
        {
            List<SittersGetAllResponseModel> expectedSitters = new List<SittersGetAllResponseModel>();
            foreach( var sitter in sitters)
            {
                var sitterId = _sitterSteps.RegisterSitterTest(sitter);
                expectedSitters.Add(_sitterMappers.MappSitterRegistrationModelToSittersGetAllResponseModel(sitterId, _date, sitter));
            }
            _sitterSteps.GetAllInfoAllSittersTest(_anonimToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(_clientToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(_sitterToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(_adminToken, expectedSitters);
        }

        [Test]
        public void GetAllInfoAboutSitter_ByAnonim_ShouldReturnAllInfoAboutCurrentSitter()
        {
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _anonimToken, _expectedSitter);
        }

        [Test]
        public void GetAllInfoAboutSitter_ByClient_ShouldReturnAllInfoAboutCurrentSitter()
        {
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _clientToken, _expectedSitter);
        }

        [Test]
        public void GetAllInfoAboutSitter_ByAdmin_ShouldReturnAllInfoAboutCurrentSitter()
        {
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _adminToken, _expectedSitter);
        }

        [TestCaseSource(typeof(GetAllSittersByAnyRoleTestSource))]
        public void GetAllInfoAboutSitter_BySitter_ShouldReturnAllInfoAboutCurrentSitter(List<SitterRegistrationRequestModel> sitters)
        {
            List<SitterAllInfoResponseModel> expectedSitters = new List<SitterAllInfoResponseModel>();
            foreach (var sitter in sitters)
            {
                var sitterId = _sitterSteps.RegisterSitterTest(sitter);
                expectedSitters.Add(_sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, _date, sitter));
            }
            foreach (var sitter in expectedSitters)
            {
                _sitterSteps.GetAllInfoSitterByIdTest(sitter.Id, _sitterToken, sitter);
            }
        }
    }
}