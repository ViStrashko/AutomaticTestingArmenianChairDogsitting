using AutomaticTestingArmenianChairDogsitting.Clients;
using System.Net;

namespace AutomaticTestingArmenianChairDogsitting.Steps
{
    public class AdminSteps
    {
        private AdminClient _adminClient;
        
        public AdminSteps()
        {
            _adminClient = new AdminClient();
        }

        public void RestoreSittersProfileTest(int sitterId, string adminToken)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;
            _adminClient.RestoreSitter(sitterId, adminToken, expectedCode);
        }
    }
}
