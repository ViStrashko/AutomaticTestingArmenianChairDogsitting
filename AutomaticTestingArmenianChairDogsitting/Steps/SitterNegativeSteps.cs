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

        public void RestoreSitterBySitterOrClientNegativeTest(int sitterId, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Forbidden;
            _sittersClient.RestoreSitterProfileBySitterId(sitterId, token, expectedCode);
        }

        public void RestoreSitterByAnonimNegativeTest(int sitterId, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Unauthorized;
            _sittersClient.RestoreSitterProfileBySitterId(sitterId, token, expectedCode);
        }

        public void RestoreSitterWithNegativeIdTest(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.BadRequest;
            _sittersClient.RestoreSitterProfileBySitterId(id, token, expectedCode);
        }
    }
}
