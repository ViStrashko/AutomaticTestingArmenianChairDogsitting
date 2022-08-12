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
        private SitterNegativeSteps _sitterNegativeSteps;

        public RegistrationNegativeTests()
        {
            _clientNegativeSteps = new ClientNegativeSteps();
            _clearingTables = new ClearingTables();
            _sitterNegativeSteps = new SitterNegativeSteps();
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

        [TestCaseSource(typeof(SitterCreationNegativeTest_WhenSittersPropertyIsEmptyOrIsNotCorrect_TestSource))]
        public void SitterCreationNegativeTest_WhenSittersPropertyIsEmptyOrIsNotCorrect_ShouldReturnHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitter)
        {
            _sitterNegativeSteps.RegisterSitterNegativeTest(sitter);
        }

        [TestCaseSource(typeof(SitterCreationNegativeTest_WhenSittersPropertyPhoneAndEmailIncorrectFormat_TestSource))]
        public void SitterCreationNegativeTest_WhenSittersPropertyPhoneAndEmailIncorrectFormat_ShouldReturnHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitter)
        {
            _sitterNegativeSteps.RegisterSitterNegativeTest(sitter);
        }

        [TestCaseSource(typeof(SitterCreationNegativeTest_WhenSittersPropertyPasswordAndPhoneIsNotCorrectLength_TestSource))]
        public void SitterCreationNegativeTest_WhenSittersPropertyPasswordAndPhoneIsNotCorrectLength_ShouldReturnHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitter)
        {
            _sitterNegativeSteps.RegisterSitterNegativeTest(sitter);
        }
    }
}
