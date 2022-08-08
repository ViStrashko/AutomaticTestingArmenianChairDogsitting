using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class OrderingService_WhenOrderModelIsCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new PriceCatalogResponseModel()
            {
                Service = 1,
                Price = 500,
            };
        }
    }
}
