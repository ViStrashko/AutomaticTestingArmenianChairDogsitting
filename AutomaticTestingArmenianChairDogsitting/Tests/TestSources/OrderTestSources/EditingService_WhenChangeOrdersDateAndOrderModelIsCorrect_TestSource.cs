using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class EditingService_WhenChangeOrdersDateAndOrderModelIsCorrect_TestSource : IEnumerable
    {
        DateTime date = DateTime.Now;
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new PriceCatalogResponseModel()
                {
                    Service = 1,
                    Price = 500,
                },
                new OrderUpdateRequestModel()
                {
                    WorkDate = date.AddDays(1),
                }
            };
        }
    }
}
