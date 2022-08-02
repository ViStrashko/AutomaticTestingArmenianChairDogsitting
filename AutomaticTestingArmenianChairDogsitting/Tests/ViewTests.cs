using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.TestsCaseSources;
using AutomaticTestingArmenianChairDogsitting.DBController;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class ViewTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearBase _clearBase;

        public ViewTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearBase = new ClearBase();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearBase.ClearAllBase();
        }

        [TearDown]
        public void TearDown()
        {
            _clearBase.ClearAllBase();
        }

        [TestCaseSource(typeof(GetAllSittes_ByAllRolesTestCaseSource))]
        public void GetAllSittesTest_ByAllRoles_ShouldReturnAllSitters(List<SitterRegistrationRequestModel> sitters, ClientRegistrationRequestModel client)
        {
            int[] sittersIds = new int[sitters.Count];
            List<string> tokens = new List<string>();
            List<AuthRequestModel> sittersAuthRequests = new List<AuthRequestModel>();

            for (int i = 0; i<sittersIds.Length; i++)
            {
                sittersIds[i] = _sitterSteps.RegisterSitter(sitters[i]);
                tokens.Add(_authorization.Authorize(sittersAuthRequests[i]));
            }
            int clientId = _clientSteps.RegisterClient(client);
            tokens.Add(_authorization.Authorize(new AuthRequestModel() { Email = client.Email, Password = client.Password }));
            tokens.Add(_authorization.Authorize(new AuthRequestModel() { Email = null,Password = null }));
            //tokens.Add(_authorization.Authorize(new AuthRequestModel() { Email = ,Password = })); for admin role

            
            List<SittersGetAllResponse> expectedAllSitters = new List<SittersGetAllResponse>();

            _sitterSteps.GetAllInfoAllSitters(tokenNonAuthorized, expectedAllSitters);
            _sitterSteps.GetAllInfoAllSitters(tokenSitter0, expectedAllSitters);
            _sitterSteps.GetAllInfoAllSitters(tokenSitter1, expectedAllSitters);
            _sitterSteps.GetAllInfoAllSitters(tokenClient, expectedAllSitters);
        }
    }
}
