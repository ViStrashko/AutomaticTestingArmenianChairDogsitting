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
        ClientRegistrationRequestModel _clientModel;
        SitterRegistrationRequestModel _sitterModel;

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
            _sitterSteps.RegisterSitterTest(_sitterModel);
            AuthRequestModel authSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_sitterModel);
            _sitterToken = _authorization.AuthorizeTest(authSitterModel);

        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(GetAllSittersByAnyRoleTestSource))]
        public void GetAllSittesTest_ByAllRoles_ShouldReturnAllSitters(List<SitterRegistrationRequestModel> sitters)
        {
            var date = DateTime.Now;
            List<SittersGetAllResponseModel> expectedSitters = new List<SittersGetAllResponseModel>();
            foreach( var sitter in sitters)
            {
                int sitterId = _sitterSteps.RegisterSitterTest(sitter);
                expectedSitters.Add(_sitterMappers.MappSitterRegistrationModelToSittersGetAllResponseModel(sitterId, date, sitter));
            }
            var sitterToken = _authorization.AuthorizeTest(new AuthRequestModel { Email = sitters[0].Email, Password = sitters[0].Password });
            _sitterSteps.GetAllInfoAllSittersTest(_anonimToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(_clientToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(sitterToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(_adminToken, expectedSitters);
        }

        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_ByAnonim_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            var date = DateTime.Now;
            var sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, date, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _anonimToken, expectedSitter);
        }

        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_ByClient_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            var date = DateTime.Now;
            var sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, date, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _clientToken, expectedSitter);
        }

        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_ByAdmin_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            var date = DateTime.Now;
            var sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, date, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _adminToken, expectedSitter);
        }

        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_BySitter_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            var date = DateTime.Now;
            var sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, date, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _sitterToken, expectedSitter);
        }
    }
}