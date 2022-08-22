using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ViewTestSources;

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
            ClientRegistrationRequestModel clientModel = new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "12345678",
                Promocode = ""
            };
            _clientSteps.RegisterClientTest(clientModel);
            AuthRequestModel authModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(clientModel);
            _clientToken = _authorization.AuthorizeTest(authModel);
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
                int sitterId = _sitterSteps.RegisterSitterTest(sitter);
                expectedSitters.Add(_sitterMappers.MappSitterRegistrationModelToSittersGetAllResponseModel(sitterId, sitter));
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
            var sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _anonimToken, expectedSitter);
        }

        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_ByClient_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            var sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _clientToken, expectedSitter);
        }

        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_ByAdmin_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            var sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _adminToken, expectedSitter);
        }
    }
}