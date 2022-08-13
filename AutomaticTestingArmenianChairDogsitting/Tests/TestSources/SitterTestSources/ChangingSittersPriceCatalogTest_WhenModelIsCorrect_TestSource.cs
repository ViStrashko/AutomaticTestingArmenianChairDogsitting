using System.Collections;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Models.Request;


namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.SitterTestSources
{
    public class ChangingSittersPriceCatalogTest_WhenModelIsCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                { 
                    new PriceCatalogRequestModel(){ Price = 500, Service = 1},
                    new PriceCatalogRequestModel(){ Price = 600, Service = 2},
                    new PriceCatalogRequestModel(){ Price = 800, Service = 3},
                    new PriceCatalogRequestModel(){ Price = 1000, Service = 4},
                }
            };
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel(){ Price = 1000, Service = 4},
                }
            };
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel(){ Price = 500, Service = 1},
                    new PriceCatalogRequestModel(){ Price = 1000, Service = 4},
                }
            };
            yield return new PriceCatalogUpdateModel()
            {
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel(){ Price = 590, Service = 1},
                    new PriceCatalogRequestModel(){ Price = 400, Service = 2},
                    new PriceCatalogRequestModel(){ Price = 1100, Service = 3},
                }
            };
        }
    }
}
