﻿using AutomaticTestingArmenianChairDogsitting.Clients;
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

        public void EditingSitterProfileWhenSitterModelIsNotCorrectNegativeTest(string token, SitterUpdateRequestModel model)
        {
            HttpStatusCode expectedCode = HttpStatusCode.UnprocessableEntity;
            _sittersClient.UpdateSitter(model, token, expectedCode);
        }
    }
}
