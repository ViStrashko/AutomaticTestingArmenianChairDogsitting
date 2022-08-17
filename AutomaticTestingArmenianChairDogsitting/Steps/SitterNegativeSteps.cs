using AutomaticTestingArmenianChairDogsitting.Clients;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Net;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class SitterNegativeSteps
    {
        private SittersClient _sittersClient;

        public SitterNegativeSteps()
        {
            _sittersClient = new SittersClient();
        }

        public void RegisterSitterNegativeTest(SitterRegistrationRequestModel sitter)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.RegisterSitter(sitter, expectedCode);
        }

        public void RestoreSitterProfileBySitterOrClientNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            _sittersClient.RestoreSitterProfileBySitterId(id, token, expectedCode);
        }

        public void RestoreSitterProfileByAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
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

        public void EditingSitterProfileByClientOrAdminOrAlienSitterNegativeTest(SitterUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            _sittersClient.UpdateSitter(model, token, expectedCode);
        }

        public void EditingSitterProfileByAnonimNegativeTest(SitterUpdateRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
            _sittersClient.UpdateSitter(model, token, expectedCode);
        }

        public void DeleteSitterProfileWhenSitterIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.BadRequest;
            _sittersClient.DeleteSitterById(id, token, expectedCode);
        }

        public void DeleteSitterProfileByClientOrAlienSitterNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            _sittersClient.DeleteSitterById(id, token, expectedCode);
        }

        public void DeleteSitterProfileByAnonimNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
            _sittersClient.DeleteSitterById(id, token, expectedCode);
        }

        public void ChangeSitterPasswordWhenPasswordModelIsNotCorrectNegativeTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.UpdateSittersPassword(model, token, expectedCode);
        }

        public void ChangeSitterPasswordByClientOrAdminOrAlienSitterNegativeTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            _sittersClient.UpdateSittersPassword(model, token, expectedCode);
        }

        public void ChangeSitterPasswordByAnonimNegativeTest(ChangePasswordRequestModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
            _sittersClient.UpdateSittersPassword(model, token, expectedCode);
        }

        public void ChangeSitterPriceCatalogWhenPriceCatalogModelIsNotCorrectNegativeTest(PriceCatalogUpdateModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.UpdatePriceCatalog(model, token, expectedCode);
        }

        public void ChangeSitterPriceCatalogByClientOrAdminOrAlienSitterNegativeTest(PriceCatalogUpdateModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            _sittersClient.UpdatePriceCatalog(model, token, expectedCode);
        }

        public void ChangeSitterPriceCatalogByAnonimNegativeTest(PriceCatalogUpdateModel model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
            _sittersClient.UpdatePriceCatalog(model, token, expectedCode);
        }

        public void GetSitterProfileWhenSitterIdIsNotCorrectNegativeTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            _sittersClient.GetAllInfoSitterById(id, token, expectedCode);
        }
    }
}
