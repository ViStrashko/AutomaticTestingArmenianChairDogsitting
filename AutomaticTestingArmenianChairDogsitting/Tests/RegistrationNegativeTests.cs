using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class RegistrationNegativeTests
    {
        private Authorizations _authorization;
        private ClientNegativeSteps _clientNegativeSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private ClientMappers _clientMappers;
        private SitterMappers _sitterMappers;

        public RegistrationNegativeTests()
        {
            _authorization = new Authorizations();
            _clientNegativeSteps = new ClientNegativeSteps();
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

        [TestCaseSource(typeof(ClientCreationNegativeTest_WhenClientsPropertyIsEmpty_TetsSource))]
        public void ClientCreationNegativeTest_WhenClientsPropertyIsEmpty_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRegistrationRequestModel clientModel)
        {
            _clientNegativeSteps.RegisterClientNegativeTest(clientModel);
        }

        [TestCaseSource(typeof(ClientCreationNegativeTest_WhenClientsPropertyPasswordAndEmailIncorrectFormat_TetsSource))]
        public void ClientCreationNegativeTest_WhenClientsPropertyPasswordAndEmailIncorrectFormat_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRegistrationRequestModel clientModel)
        {
            _clientNegativeSteps.RegisterClientNegativeTest(clientModel);
        }

        [TestCaseSource(typeof(ClientCreationNegativeTest_WhenClientsPropertyPasswordIsNotCorrectLength_TetsSource))]
        public void ClientCreationNegativeTest_WhenClientsPropertyPasswordIsNotCorrectLength_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRegistrationRequestModel clientModel)
        {
            _clientNegativeSteps.RegisterClientNegativeTest(clientModel);
        }
    }
}
