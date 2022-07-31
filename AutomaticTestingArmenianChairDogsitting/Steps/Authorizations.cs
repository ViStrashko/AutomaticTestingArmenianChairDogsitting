﻿using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Clients;
using System.Net;
using System.Net.Http;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class Authorizations
    {
        private Authorizations _authorization;
        private AuthClient _authClient = new AuthClient();

        public Authorizations()
        {
            _authorization = new Authorizations();
        }
        public string Authorize(AuthRequestModel authModel)
        {
            //Given
            HttpStatusCode expectedAuthCode = HttpStatusCode.Created;
            //When
            HttpContent content = _authClient.Authorize(authModel, expectedAuthCode);
            string actualToken = content.ReadAsStringAsync().Result;
            //Then
            Assert.NotNull(actualToken);

            return actualToken;
        }
    }
}
