﻿using NUnit.Framework;
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
            //Given
            HttpStatusCode expectedAuthCode = HttpStatusCode.OK;
            //When
            HttpContent content = _authClient.Authorize(authModel, expectedAuthCode);
            string actualToken = content.ReadAsStringAsync().Result;
            //Then
            Assert.NotNull(actualToken);

            return actualToken;
        }
    }
}
