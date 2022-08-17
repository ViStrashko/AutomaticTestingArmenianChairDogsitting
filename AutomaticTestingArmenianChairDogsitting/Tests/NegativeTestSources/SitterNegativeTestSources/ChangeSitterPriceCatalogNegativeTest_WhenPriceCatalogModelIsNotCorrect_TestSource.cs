using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class ChangeSitterPriceCatalogNegativeTest_WhenPriceCatalogModelIsNotCorrect_TestSource :IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Price = 0,
                        Service = 1
                    }
                }
            };
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Price = -1,
                        Service = 1
                    }
                }
            };
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Price = 500,
                        Service = 0
                    }
                }
            };
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Price = 500,
                        Service = 5
                    }
                }
            };
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Price = 500,
                        Service = -10
                    }
                }
            };
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Price = 500,
                        Service = 10
                    }
                }
            };
        }
    }
}
