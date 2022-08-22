using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class EditingServiceDailySitting_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource : IEnumerable
    {
        DateTime date = DateTime.Now;
        public IEnumerator GetEnumerator()
        {
            yield return new OrderDailySittingUpdateRequestModel()
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
