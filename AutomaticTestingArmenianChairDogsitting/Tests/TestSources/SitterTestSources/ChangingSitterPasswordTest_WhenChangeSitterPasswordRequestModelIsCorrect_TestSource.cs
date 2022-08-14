using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.SitterTestSources
{
    public class ChangingSitterPasswordTest_WhenChangeSitterPasswordRequestModelIsCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ChangePasswordRequestModel()
            {
                Password = "82938192",
            };
            yield return new ChangePasswordRequestModel()
            {
                Password = "82977192",
            };
            yield return new ChangePasswordRequestModel()
            {
                Password = "11138192",
            };
            yield return new ChangePasswordRequestModel()
            {
                Password = "82777792",
            };
            yield return new ChangePasswordRequestModel()
            {
                Password = "82999892",
            };
        }
    }
}
