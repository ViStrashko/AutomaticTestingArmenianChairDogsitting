using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class EditingService_WhenChangeOrdersAddressAndOrderModelIsCorrect_TestSource : IEnumerable
    {
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
                    Address = "Каменноостровский проспект, дом 10",
                }
            };
        }
    }
}
