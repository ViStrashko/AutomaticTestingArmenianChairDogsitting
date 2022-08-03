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

    public int RegisterSitter(SitterRegistrationRequestModel model)
        {
            //Given
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            //When
            HttpContent content = _sittersClient.RegisterSitter(model, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            //Then
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);

            return (int)actualId;
        }

        public SitterAllInfoResponseModel GetAllInfoSitterById(int id, string token, SitterAllInfoResponseModel expectedClient)
        {
            //When
            HttpContent content = _sittersClient.GetAllInfoSitterById(id, token, HttpStatusCode.OK);
            SitterAllInfoResponseModel actualClient = JsonSerializer.Deserialize<SitterAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            //Then
            Assert.AreEqual(expectedClient, actualClient);

            return actualClient;
        }

        public void UpdateSitterById(int id, string token, SitterUpdateRequestModel model)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _sittersClient.UpdateSitterById(id, token, model, expectedUpdateCode);
        }

        public void DeleteSitterById(int id, string token)
        {
            //Given
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            //When
            _sittersClient.DeleteSitterById(id, token, expectedUpdateCode);
        }

        public List<SitterAllInfoResponseModel> GetAllInfoAllSitters(string token, List<SitterAllInfoResponseModel> expectedAllSitters)
        {
            HttpContent content = _sittersClient.GetAllInfoAllSitters(token, HttpStatusCode.OK);
            List<SitterAllInfoResponseModel> actualAllSitters = JsonSerializer.Deserialize<List<SitterAllInfoResponseModel>>(content.ReadAsStringAsync().Result)!;
            
            CollectionAssert.AreEqual(expectedAllSitters, actualAllSitters);
            return actualAllSitters;

        }
        public List<SittersGetAllResponse> GetAllSittersTest(string token, List<SittersGetAllResponse> expectedAllSitters)
        {
            HttpContent content = _sittersClient.GetAllInfoAllSitters(token, HttpStatusCode.OK);
            List<SittersGetAllResponse> actualAllSitters = JsonSerializer.Deserialize<List<SittersGetAllResponse>>(content.ReadAsStringAsync().Result)!;

            CollectionAssert.AreEquivalent(expectedAllSitters, actualAllSitters);
            return actualAllSitters;
        }
    }
}
