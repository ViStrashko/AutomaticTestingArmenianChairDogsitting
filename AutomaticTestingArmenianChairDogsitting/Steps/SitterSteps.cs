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
        private OrdersClient _ordersClient;
        private CommentsClient _commentsClient;

        public SitterSteps()
        {
            _sittersClient = new SittersClient();
            _ordersClient = new OrdersClient();
            _commentsClient = new CommentsClient();
        }

        public int RegisterSitterTest(SitterRegistrationRequestModel model)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _sittersClient.RegisterSitter(model, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }

        public SitterAllInfoResponseModel GetAllInfoSitterByIdTest(int id, string token, SitterAllInfoResponseModel expectedSitter)
        {
            HttpContent content = _sittersClient.GetAllInfoSitterById(id, token, HttpStatusCode.OK);
            SitterAllInfoResponseModel actualSitter = JsonSerializer.Deserialize<SitterAllInfoResponseModel>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.AreEqual(actualSitter.PriceCatalog, expectedSitter.PriceCatalog);
            Assert.AreEqual(expectedSitter, actualSitter);
            return actualSitter;
        }

        public List<SittersGetAllResponseModel> GetAllInfoAllSittersTest(string token, List<SittersGetAllResponseModel> expectedSitters)
        {
            HttpContent content = _sittersClient.GetAllSitters(token, HttpStatusCode.OK);
            List<SittersGetAllResponseModel> actualSitters = JsonSerializer.Deserialize<List<SittersGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;
            CollectionAssert.AreEquivalent(expectedSitters, actualSitters);
            return actualSitters;
        }

        public void UpdateSitterTest(SitterUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _sittersClient.UpdateSitter(model, token, expectedUpdateCode);
        }

        public void DeleteSitterTest(string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _sittersClient.DeleteSitter(token, expectedDeleteCode);
        }

        public void ChangeSittersPasswordTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _sittersClient.UpdateSittersPassword(model, token, expectedUpdateCode);
        }

        public void UpdatePriceCatalogTest(PriceCatalogUpdateModel newPrices, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;
            _sittersClient.UpdatePriceCatalog(newPrices, token, expectedCode);
        }

        public List<SittersGetAllResponseModel> CheckThatAllSittersDoesNotContainsDeletedSitterTest(string token, SittersGetAllResponseModel expectedSitter)
        {
            HttpContent content = _sittersClient.GetAllSitters(token, HttpStatusCode.OK);
            List<SittersGetAllResponseModel> actualSitters = 
                JsonSerializer.Deserialize<List<SittersGetAllResponseModel>>(content.ReadAsStringAsync().Result)!;            
            CollectionAssert.DoesNotContain(actualSitters, expectedSitter);
            return actualSitters;
        }

        public void UpdateOrderStatusByOrderIdTest(int id, int ststusUpdate, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.NoContent;
            _ordersClient.UpdateOrderStatusByOrderId(id, ststusUpdate, token, expectedUpdateCode);
        }

        public int RegisterCommentToOrderTest(int id, CommentRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            HttpContent content = _ordersClient.RegisterCommentToOrder(id, model, token, expectedRegistrationCode);
            int actualId = Convert.ToInt32(content.ReadAsStringAsync().Result);
            Assert.NotNull(actualId);
            Assert.IsTrue(actualId > 0);
            return actualId;
        }

        public void DeleteCommentByIdTest(int id, string token)
        {
            HttpStatusCode expectedDeleteCode = HttpStatusCode.NoContent;
            _commentsClient.DeleteCommentById(id, token, expectedDeleteCode);
        }
    }
}
