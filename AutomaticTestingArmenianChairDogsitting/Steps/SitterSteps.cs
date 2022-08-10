using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Clients;
using System;
using System.Net;
using System.Net.Http;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Text.Json;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class SitterSteps
    {
        private SittersClient _sittersClient;

        public SitterSteps()
        {
            _sittersClient = new SittersClient();
        }

        public int RegisterSitterTest(SitterRegistrationRequestModel model)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _sittersClient.RegisterSitter(model, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return actualId;
        }

        public void RegisterSitterNegativeTest(SitterRegistrationRequestModel sitter)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.RegisterSitter(sitter, expectedCode);
        }

        public SitterAllInfoResponseModel GetAllInfoSitterByIdTest(int id, string token, SitterAllInfoResponseModel expectedSitter)
        {
            //When
            HttpContent content = _sittersClient.GetAllInfoSitterById(id, token, HttpStatusCode.OK);
            SitterAllInfoResponseModel actualSitter = JsonSerializer.Deserialize<SitterAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedSitter, actualSitter);

            return actualSitter;
        }

        public List<SitterAllInfoResponseModel> GetAllInfoAllSittersTest(string token, List<SitterAllInfoResponseModel> expectedSitters)
        {
            List<SitterAllInfoResponseModel> actualSitters = new List<SitterAllInfoResponseModel>();
            HttpContent content = _sittersClient.GetAllSitters(token, HttpStatusCode.OK);
            actualSitters = JsonSerializer.Deserialize<List<SitterAllInfoResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.AreEquivalent(expectedSitters, actualSitters);

            return actualSitters;
        }
        public void UpdateSitterByIdTest(int id, SitterUpdateRequestModel model, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _sittersClient.UpdateSitterById(id, model, token, expectedUpdateCode);
        }

        public void DeleteSitterByIdTest(int id, string token)
        {
            //Given
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            //When
            _sittersClient.DeleteSitterById(id, token, expectedDeleteCode);
        }

        public void ChangeSittersPasswordTest(int id, ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;

            _sittersClient.UpdateSittersPassword(id, model, token, expectedUpdateCode);
        }
    }
}
