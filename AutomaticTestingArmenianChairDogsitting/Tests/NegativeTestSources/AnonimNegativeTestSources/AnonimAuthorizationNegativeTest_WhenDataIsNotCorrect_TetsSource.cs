using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.AnonimNegativeTestSources
{
    internal class AnonimAuthorizationNegativeTest_WhenDataIsNotCorrect_TetsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new AuthRequestModel()
            {
                Email = "",
                Password = "12345678",
            };
            yield return new AuthRequestModel()
            {
                Email = "petrov@gmail.com",
                Password = "",
            };
            yield return new AuthRequestModel()
            {
                Email = "",
                Password = "",
            };
            yield return new AuthRequestModel()
            {
                Email = "petrovgmail.com",
                Password = "12345678",
            };
            yield return new AuthRequestModel()
            {
                Email = "petrov@gmail",
                Password = "12345678",
            };
            yield return new AuthRequestModel()
            {
                Email = "petrov@gmail.com",
                Password = "1234567",
            };
            yield return new AuthRequestModel()
            {
                Email = "petrov@gmail.com",
                Password = "1",
            };
        }
    }
}
