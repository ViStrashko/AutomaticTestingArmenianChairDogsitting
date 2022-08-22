using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Clients;
using System.Net;
using System.Net.Http;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class Authorizations
    {
        private AuthClient _authClient;

        public Authorizations()
        {
            _authClient = new AuthClient();
        }
        public string AuthorizeTest(AuthRequestModel authModel)
        {
            HttpStatusCode expectedAuthCode = HttpStatusCode.OK;
            HttpContent content = _authClient.Authorize(authModel, expectedAuthCode);
            string actualToken = content.ReadAsStringAsync().Result;
            Assert.NotNull(actualToken);
            return actualToken;
        }

        public void AuthorizeWhenPasswordOrEmailIsNotCorrectNegativeTest(AuthRequestModel authModel)
        {
            HttpStatusCode expectedAuthCode = HttpStatusCode.UnprocessableEntity;
            _authClient.Authorize(authModel, expectedAuthCode);
        }

        public void AuthorizeWhenAuthenticationFailedNegativeTest(AuthRequestModel authModel)
        {
            HttpStatusCode expectedAuthCode = HttpStatusCode.Unauthorized;
            _authClient.Authorize(authModel, expectedAuthCode);
        }
    }
}
