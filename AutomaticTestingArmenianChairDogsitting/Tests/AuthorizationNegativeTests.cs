using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class AuthorizationNegativeTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private ClearingTables _clearingTables;

        public AuthorizationNegativeTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _clearingTables = new ClearingTables();
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

        [TestCaseSource(typeof(ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsStrangers_TetsSource))]
        public void ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsStrangers_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRegistrationRequestModel clientModel, AuthRequestModel authModel)
        {
            _clientSteps.RegisterClientTest(clientModel);
            _authorization.AuthorizeWhenAuthenticationFailedNegativeTest(authModel);
        }

        [TestCaseSource(typeof(ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsNotCorrect_TetsSource))]
        public void ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsNotCorrect_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientRegistrationRequestModel clientModel, AuthRequestModel authModel)
        {
            _clientSteps.RegisterClientTest(clientModel);
            _authorization.AuthorizeWhenPasswordOrEmailIsNotCorrectNegativeTest(authModel);
        }

        [TestCaseSource(typeof(ClientAuthorizationNegativeTest_WhenClientIsNotRegisteredAndDataIsCorrect_TetsSource))]
        public void ClientAuthorizationNegativeTest_WhenClientIsNotRegisteredAndDataIsCorrect_ShouldGetHttpStatusCodeUnauthorized
            (AuthRequestModel authModel)
        {
            _authorization.AuthorizeWhenAuthenticationFailedNegativeTest(authModel);
        }

        [TestCaseSource(typeof(ClientAuthorizationNegativeTest_WhenClientIsNotRegisteredAndDataIsNotCorrect_TetsSource))]
        public void ClientAuthorizationNegativeTest_WhenClientIsNotRegisteredAndDataIsNotCorrect_ShouldGetHttpStatusCodeUnauthorized
            (AuthRequestModel authModel)
        {
            _authorization.AuthorizeWhenPasswordOrEmailIsNotCorrectNegativeTest(authModel);
        }
    }
}
