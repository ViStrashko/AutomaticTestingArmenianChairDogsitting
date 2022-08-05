using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class DeleteService_WhenOrderIdIsCorrect_TestSource : IEnumerable
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
