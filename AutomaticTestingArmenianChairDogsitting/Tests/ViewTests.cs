using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ViewTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class ViewTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private SitterMappers _sitterMappers;
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
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.ClearAllDB();
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
            };
            int clientId = _clientSteps.RegisterClientTest(clientModel);
            _clientToken = _authorization.AuthorizeTest(new AuthRequestModel()
            {
                Email = clientModel.Email,
                Password = clientModel.Password
            });
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [Test]
        [TestCaseSource(typeof(GetAllSittersByAnyRoleTestSource))]
        public void GetAllSittesTest_ByAllRoles_ShouldReturnAllSitters(List<SitterRegistrationRequestModel> sitters)
        {
            List<SitterAllInfoResponseModel> expectedSitters = new List<SitterAllInfoResponseModel>();
            foreach( var sitter in sitters)
            {
                int sitterId = _sitterSteps.RegisterSitterTest(sitter);
                expectedSitters.Add(_sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, sitter));
            }
            string sitterToken = _authorization.AuthorizeTest(new AuthRequestModel { Email = sitters[0].Email, Password = sitters[0].Password });
            _sitterSteps.GetAllInfoAllSittersTest(_anonimToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(_clientToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(sitterToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(_adminToken, expectedSitters);
        }

        [Test]
        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_ByAnonim_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            int sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _anonimToken, expectedSitter);
        }

        [Test]
        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_ByClient_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            int sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _clientToken, expectedSitter);
        }

        [Test]
        [TestCaseSource(typeof(GetAllInfoSitterTestSource))]
        public void GetAllInfoAboutSitter_ByAdmin_ShouldReturnAllInfoAboutCurrentSitter(SitterRegistrationRequestModel sitter)
        {
            int sitterId = _sitterSteps.RegisterSitterTest(sitter);
            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, sitter);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, _adminToken, expectedSitter);
        }

    }
}