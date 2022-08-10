using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class RegistrationNegativeTests
    {
        private ClientNegativeSteps _clientNegativeSteps;
        private ClearingTables _clearingTables;
        private SitterSteps _sitterSteps;

        public RegistrationNegativeTests()
        {
            _clientNegativeSteps = new ClientNegativeSteps();
            _clearingTables = new ClearingTables();
            _sitterSteps = new SitterSteps();
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

        [TestCaseSource(typeof(ClientCreationNegativeTest_WhenClientsPropertyPhoneAndEmailIncorrectFormat_TetsSource))]
        public void ClientCreationNegativeTest_WhenClientsPropertyPhoneAndEmailIncorrectFormat_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRegistrationRequestModel clientModel)
        {
            _clientNegativeSteps.RegisterClientNegativeTest(clientModel);
        }

        [TestCaseSource(typeof(ClientCreationNegativeTest_WhenClientsPropertyPasswordAndPhoneIsNotCorrectLength_TetsSource))]
        public void ClientCreationNegativeTest_WhenClientsPropertyPasswordAndPhoneIsNotCorrectLength_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRegistrationRequestModel clientModel)
        {
            _clientNegativeSteps.RegisterClientNegativeTest(clientModel);
        }

        [Test]
        [TestCaseSource(typeof(SitterRegistrationWrongModelNegativeTestSources))]
        public void SitterCreationNegativeTest_WhenModelIsNotCorrect_ShouldReturnHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitter)
        {
            _sitterSteps.RegisterSitterNegativeTest(sitter);
        }
    }
}
