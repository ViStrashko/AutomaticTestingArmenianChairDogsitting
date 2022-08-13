using AutomaticTestingArmenianChairDogsitting.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
