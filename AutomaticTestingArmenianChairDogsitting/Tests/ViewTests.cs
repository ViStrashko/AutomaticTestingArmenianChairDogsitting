using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.TestsCaseSources;
using AutomaticTestingArmenianChairDogsitting.DBController;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class ViewTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearBase _clearBase;
        private SittersMapper _mapper;

        public ViewTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearBase = new ClearBase();
            _mapper = new SittersMapper();
        }

        //[OneTimeSetUp]
        //public void OneTimeSetUp()
        //{
        //    _clearBase.ClearAllBase();
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    _clearBase.ClearAllBase();
        //}

        [TestCaseSource(typeof(GetAllSittes_ByAllRolesTestCaseSource))]
        public void GetAllSittesTest_ByAllRoles_ShouldReturnAllSitters(List<SitterRegistrationRequestModel> sitters, ClientRegistrationRequestModel client)
        {
            List<int> sittersIds = new List<int>();
            List<string> tokens = new List<string>();
            List<AuthRequestModel> sittersAuthRequests = new List<AuthRequestModel>();
            List<SittersGetAllResponse> expectedAllSitters = new List<SittersGetAllResponse>();
            foreach(var sitter in sitters)
            {
                sittersIds.Add(_sitterSteps.RegisterSitter(sitter));
            }
            for(int i = 0; i < sittersIds.Count; i++)
            {
                expectedAllSitters.Add(_mapper.MapSitterRegistModelToSitterGetAllResponse(sitters[i], sittersIds[i]));
                sittersAuthRequests.Add(_mapper.MapSitterRegistModelToAuthModel(sitters[i]));
            }
            foreach (var sitter in sittersAuthRequests)
            {
                tokens.Add(_authorization.Authorize(sitter));
            }
            //int clientId = _clientSteps.RegisterClient(client);
            //tokens.Add(_authorization.Authorize(new AuthRequestModel() { Email = client.Email, Password = client.Password }));
            //tokens.Add(_authorization.Authorize(new AuthRequestModel() { Email = null,Password = null }));
            //tokens.Add(_authorization.Authorize(new AuthRequestModel() { Email = ,Password = })); for admin role
            foreach (var token in tokens)
            {
                _sitterSteps.GetAllSitters(token, expectedAllSitters);
            }
        }
    }
}
