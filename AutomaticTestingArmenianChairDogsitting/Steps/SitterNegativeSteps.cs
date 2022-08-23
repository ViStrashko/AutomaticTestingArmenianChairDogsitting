using AutomaticTestingArmenianChairDogsitting.Clients;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Net;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class SitterNegativeSteps
    {
        private SittersClient _sittersClient;
        private OrdersClient _ordersClient;

        public SitterNegativeSteps()
        {
            _sittersClient = new SittersClient();
        }

        public void RegisterSitterNegativeTest(SitterRegistrationRequestModel sitter)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.RegisterSitter(sitter, expectedCode);
        }

        public void RestoreSitterProfileBySitterOrClientOrAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode;
            if(token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _sittersClient.RestoreSitterProfileBySitterId(id, token, expectedCode);
        }

        public void RestoreSitterProfileWithNotCorrectIdNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.BadRequest;
            _sittersClient.RestoreSitterProfileBySitterId(id, token, expectedCode);
        }

        public void EditingSitterProfileWhenSitterModelIsNotCorrectNegativeTest(SitterUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.UpdateSitter(model, token, expectedCode);
        }

        public void EditingSitterProfileByClientOrAdminOrAnonimNegativeTest(SitterUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedCode;
            if(token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _sittersClient.UpdateSitter(model, token, expectedCode);
        }

        public void DeleteSitterProfileByClientOrAnonimNegativeTest(string token)
        {
            HttpStatusCode expectedCode;
            if (token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else 
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _sittersClient.DeleteSitter(token, expectedCode);
        }

        public void ChangeSitterPasswordWhenPasswordModelIsNotCorrectNegativeTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.UpdateSittersPassword(model, token, expectedCode);
        }

        public void ChangeSitterPasswordByClientOrAdminOrAnonimNegativeTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedCode;
            if(token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _sittersClient.UpdateSittersPassword(model, token, expectedCode);
        }

        public void ChangeSitterPriceCatalogWhenPriceCatalogModelIsNotCorrectNegativeTest(PriceCatalogUpdateModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.UpdatePriceCatalog(model, token, expectedCode);
        }

        public void ChangeSitterPriceCatalogByClientOrAdminOrAnonimNegativeTest(PriceCatalogUpdateModel model, string token)
        {
            HttpStatusCode expectedCode;
            if(token != null)
            {
                expectedCode = HttpStatusCode.Forbidden;
            }
            else
            {
                expectedCode = HttpStatusCode.Unauthorized;
            }
            _sittersClient.UpdatePriceCatalog(model, token, expectedCode);
        }

        public void AddingSitterProfileBySitterOrAdminNegativeTest(SitterRegistrationRequestModel model, string token)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Forbidden;
            _sittersClient.RegisterSitterWithToken(model, token, expectedRegistrationCode);
        }

        public void GetSitterProfileWhenSitterIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            _sittersClient.GetAllInfoSitterById(id, token, expectedCode);
        }

        public void PerformServiceForDifferentClientsSimultaneouslyNegativeTest(int id, int ststusUpdate, string token)
        {
            HttpStatusCode expectedUpdateCode = HttpStatusCode.BadRequest;
            _ordersClient.UpdateOrderStatusByOrderId(id, ststusUpdate, token, expectedUpdateCode);
        }
    }
}
