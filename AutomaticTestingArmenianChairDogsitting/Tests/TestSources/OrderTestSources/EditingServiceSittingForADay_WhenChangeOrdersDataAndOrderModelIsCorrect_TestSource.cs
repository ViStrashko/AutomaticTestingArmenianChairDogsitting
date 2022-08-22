using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class EditingServiceSittingForADay_WhenChangeOrdersDataAndOrderModelIsCorrect_TestSource : IEnumerable
    {
        DateTime date = DateTime.Now;
        public IEnumerator GetEnumerator()
        {
            yield return new OrderSittingForADayUpdateRequestModel()
            {
                Address = "Каменноостровский проспект, дом 10",
                WorkDate = date.AddDays(1),
                District = 4,
                VisitQuantity = 4,
            };
        }
    }
}
