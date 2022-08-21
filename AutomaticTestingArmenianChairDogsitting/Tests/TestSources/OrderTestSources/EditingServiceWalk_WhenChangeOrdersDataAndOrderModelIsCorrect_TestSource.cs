using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class EditingServiceWalk_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource : IEnumerable
    {
        DateTime date = DateTime.Now;
        public IEnumerator GetEnumerator()
        {
            yield return new OrderWalkUpdateRequestModel()
            {
                Address = "Каменноостровский проспект, дом 10",
                WorkDate = date.AddDays(1),
                District = 4,
                IsTrial = false,
            };
        }
    }
}
