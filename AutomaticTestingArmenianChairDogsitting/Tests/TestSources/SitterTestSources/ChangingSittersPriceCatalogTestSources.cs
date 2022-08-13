using System.Collections;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Models.Request;


namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.SitterTestSources
{
    public class ChangingSittersPriceCatalogTestSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new List<PriceCatalogRequestModel>()
            {
                new PriceCatalogRequestModel() { Price = 100, Service = 1 },
                new PriceCatalogRequestModel() { Price = 200, Service = 2 },
                new PriceCatalogRequestModel() { Price = 300, Service = 3 },
                new PriceCatalogRequestModel() { Price = 400, Service = 4 }
            };
            yield return new List<PriceCatalogRequestModel>()
            {
                new PriceCatalogRequestModel() { Price = 100, Service = 1 },
                new PriceCatalogRequestModel() { Price = 400, Service = 4 }
            };
            yield return new List<PriceCatalogRequestModel>()
            {
                new PriceCatalogRequestModel() { Price = 400, Service = 4 }
            };
            yield return new List<PriceCatalogRequestModel>()
            {
                new PriceCatalogRequestModel() { Price = 100, Service = 1 },
                new PriceCatalogRequestModel() { Price = 200, Service = 2 },
                new PriceCatalogRequestModel() { Price = 400, Service = 4 }
            };
            yield return new List<PriceCatalogRequestModel>();
        }
    }
}
