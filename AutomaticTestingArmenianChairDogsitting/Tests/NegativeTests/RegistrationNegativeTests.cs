using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTests
{
    public class RegistrationNegativeTests
    {
        private ClientNegativeSteps _clientNegativeSteps;
        private ClientSteps _clientSteps;
        private ClearingTables _clearingTables;
        private SitterNegativeSteps _sitterNegativeSteps;
        private SitterSteps _sitterSteps;

        public RegistrationNegativeTests()
        {
            _clientNegativeSteps = new ClientNegativeSteps();
            _clearingTables = new ClearingTables();
            _sitterNegativeSteps = new SitterNegativeSteps();
            _clientSteps = new ClientSteps();
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

        //Client
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

        [TestCaseSource(typeof(ClientCreationNegativeTest_WhenPropertyPasswordAndEmailIsInDatabase_TetsSource))]
        public void ClientCreationNegativeTest_WhenPropertyPasswordAndEmailIsInDatabase_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRegistrationRequestModel clientModel)
        {
            _clientSteps.RegisterClientTest(clientModel);
            _clientNegativeSteps.RegisterClientNegativeTest(clientModel);
        }

        //Sitter
        [TestCaseSource(typeof(SitterCreationNegativeTest_WhenSittersPropertyIsEmptyOrIsNotCorrect_TestSource))]
        public void SitterCreationNegativeTest_WhenSittersPropertyIsEmptyOrIsNotCorrect_ShouldReturnHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitterModel)
        {
            _sitterNegativeSteps.RegisterSitterNegativeTest(sitterModel);
        }

        [TestCaseSource(typeof(SitterCreationNegativeTest_WhenSittersPropertyPhoneAndEmailIncorrectFormat_TestSource))]
        public void SitterCreationNegativeTest_WhenSittersPropertyPhoneAndEmailIncorrectFormat_ShouldReturnHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitterModel)
        {
            _sitterNegativeSteps.RegisterSitterNegativeTest(sitterModel);
        }

        [TestCaseSource(typeof(SitterCreationNegativeTest_WhenSittersPropertyPasswordAndPhoneIsNotCorrectLength_TestSource))]
        public void SitterCreationNegativeTest_WhenSittersPropertyPasswordAndPhoneIsNotCorrectLength_ShouldReturnHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitterModel)
        {
            _sitterNegativeSteps.RegisterSitterNegativeTest(sitterModel);
        }

        [TestCaseSource(typeof(SitterCreationNegativeTest_WhenPropertyPasswordAndEmailIsInDatabase_TetsSource))]
        public void SitterCreationNegativeTest_WhenPropertyPasswordAndEmailIsInDatabase_ShouldGetHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitterModel)
        {
            _sitterSteps.RegisterSitterTest(sitterModel);
            _sitterNegativeSteps.RegisterSitterNegativeTest(sitterModel);
        }
    }
}
