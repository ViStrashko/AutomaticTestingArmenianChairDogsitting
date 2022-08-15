using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ClientTestSources;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using System;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
{
    public class RegistrationTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private ClientMappers _clientMappers;
        private SitterMappers _sitterMappers;

        public RegistrationTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _clientMappers = new ClientMappers();
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

        [TestCaseSource(typeof(ClientCreationTest_WhenClientModelIsCorrect_TetsSource))]
        public void ClientCreationTest_WhenClientModelIsCorrect_ShouldCreateClient(ClientRegistrationRequestModel clientModel)
        {
            int clientId = _clientSteps.RegisterClientTest(clientModel);
            var date = DateTime.Now;

            AuthRequestModel authModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(clientModel);
            string token = _authorization.AuthorizeTest(authModel);

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientRegistrationRequestModelToClientAllInfoResponseModel
                (clientId, date, clientModel);
            _clientSteps.GetAllInfoClientByIdTest(clientId, token, expectedClient);
        }

        [TestCaseSource(typeof(SitterCreationTest_WhenSitterModelIsCorrect_TetsSource))]
        public void SitterCreationTest_WhenSitterModelIsCorrect_ShouldCreateSitter(SitterRegistrationRequestModel sitterModel)
        {
            int sitterId = _sitterSteps.RegisterSitterTest(sitterModel);

            AuthRequestModel authModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(sitterModel);
            string token = _authorization.AuthorizeTest(authModel);

            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel
                (sitterId, sitterModel);
            _sitterSteps.GetAllInfoSitterByIdTest(sitterId, token, expectedSitter);
        }
    }
}
