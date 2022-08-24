using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class EditingServiceWalk_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource : IEnumerable
    {
        private DateTime _date = DateTime.Now;
        public IEnumerator GetEnumerator()
        {
            yield return new OrderWalkUpdateRequestModel()
            {
                Address = "Каменноостровский проспект, дом 10",
                WorkDate = _date.AddDays(1),
                District = 4,
                IsTrial = false,
            };
        }
    }
}
