using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.AnonimNegativeTestSources
{
    internal class AnonimAuthorizationNegativeTest_WhenDataIsCorrect_TetsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new AuthRequestModel()
            {
                Email = "petrov@gmail.com",
                Password = "12345678",
            };
            yield return new AuthRequestModel()
            {
                Email = "smirnov@gmail.com",
                Password = "87654321",
            };
        }
    }
}
