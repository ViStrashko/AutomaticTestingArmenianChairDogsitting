using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTests
{
    public class AuthorizationNegativeTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;

        public AuthorizationNegativeTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
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

        //Client
        [TestCaseSource(typeof(ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsStrangers_TetsSource))]
        public void ClientAuthorizationNegativeTest_WhenClientIsRegisteredAndPasswordAndEmailIsStrangers_ShouldGetHttpStatusCodeUnauthorized
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
        public void ClientAuthorizationNegativeTest_WhenClientIsNotRegisteredAndDataIsNotCorrect_ShouldGetHttpStatusCodeUnprocessableEntity
            (AuthRequestModel authModel)
        {
            _authorization.AuthorizeWhenPasswordOrEmailIsNotCorrectNegativeTest(authModel);
        }

        //Sitter
        [TestCaseSource(typeof(SitterAuthorizationNegativeTest_WhenSitterIsRegisteredAndPasswordAndEmailIsStrangers_TetsSource))]
        public void SitterAuthorizationNegativeTest_WhenSitterIsRegisteredAndPasswordAndEmailIsStrangers_ShouldGetHttpStatusCodeUnauthorized
            (SitterRegistrationRequestModel sitterModel, AuthRequestModel authModel)
        {
            _sitterSteps.RegisterSitterTest(sitterModel);
            _authorization.AuthorizeWhenAuthenticationFailedNegativeTest(authModel);
        }

        [TestCaseSource(typeof(SitterAuthorizationNegativeTest_WhenSitterIsRegisteredAndPasswordAndEmailIsNotCorrectt_TetsSource))]
        public void SitterAuthorizationNegativeTest_WhenSitterIsRegisteredAndPasswordAndEmailIsNotCorrect_ShouldGetHttpStatusCodeUnprocessableEntity
            (SitterRegistrationRequestModel sitterModel, AuthRequestModel authModel)
        {
            _sitterSteps.RegisterSitterTest(sitterModel);
            _authorization.AuthorizeWhenPasswordOrEmailIsNotCorrectNegativeTest(authModel);
        }
    }
}
