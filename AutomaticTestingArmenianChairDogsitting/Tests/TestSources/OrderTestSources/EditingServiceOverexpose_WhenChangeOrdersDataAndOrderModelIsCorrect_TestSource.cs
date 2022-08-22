using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class EditingServiceOverexpose_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource : IEnumerable
    {
        DateTime date = DateTime.Now;
        public IEnumerator GetEnumerator()
        {
            yield return new OrderOverexposeUpdateRequestModel()
            {
                Address = "Каменноостровский проспект, дом 10",
                WorkDate = date.AddDays(1),
                District = 4,
                DayQuantity = 2,
                WalkPerDayQuantity = 3,
            };
        }
    }
}
