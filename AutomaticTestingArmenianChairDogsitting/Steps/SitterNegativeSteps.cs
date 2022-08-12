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
    }
}
