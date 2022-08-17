using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class ChangeSitterPasswordNegativeTest_WhenPasswordModelIsNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ChangePasswordRequestModel()
            {
                Password = "",
            };
            yield return new ChangePasswordRequestModel()
            {
                Password = "1",
            };
            yield return new ChangePasswordRequestModel()
            {
                Password = "1234567",
            };
        }
    }
}
