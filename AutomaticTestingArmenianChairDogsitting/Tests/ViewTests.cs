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
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [Test]
        [TestCaseSource(typeof(GetAllSittersByAnyRoleTestSource))]
        public void GetAllSittesTest_ByAllRoles_ShouldReturnAllSitters(List<SitterRegistrationRequestModel> sitters, ClientRegistrationRequestModel client)
        {
            List<SitterAllInfoResponseModel> expectedSitters = new List<SitterAllInfoResponseModel>();
            foreach( var sitter in sitters)
            {
                int sitterId = _sitterSteps.RegisterSitterTest(sitter);
                expectedSitters.Add(_sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(sitterId, sitter));
            }
            int clientId = _clientSteps.RegisterClientTest(client);
            string clientToken = _authorization.AuthorizeTest(new AuthRequestModel { Email = client.Email, Password = client.Password });
            string sitterToken = _authorization.AuthorizeTest(new AuthRequestModel { Email = sitters[0].Email, Password = sitters[0].Password });
            string adminToken = _authorization.AuthorizeTest(new AuthRequestModel { Email = Options.adminEmail, Password = Options.adminPassword });
            string anonimToken = null;
            _sitterSteps.GetAllInfoAllSittersTest(anonimToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(clientToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(sitterToken, expectedSitters);
            _sitterSteps.GetAllInfoAllSittersTest(adminToken, expectedSitters);
        }
    }
}