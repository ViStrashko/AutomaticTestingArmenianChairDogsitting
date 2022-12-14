using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ClientTestSources
{
    public class EditingClientProfileTest_WhenClientModelIsCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ClientUpdateRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Phone = "+79518741247",
                Address = "ул. Итальянская, дом. 10",
            };
        }
    }
}