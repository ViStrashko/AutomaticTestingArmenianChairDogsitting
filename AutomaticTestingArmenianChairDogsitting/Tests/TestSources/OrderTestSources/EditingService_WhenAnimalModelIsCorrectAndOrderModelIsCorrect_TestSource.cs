using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.OrderTestSources
{
    public class EditingService_WhenAnimalModelIsCorrectAndOrderModelIsCorrect_TestSource : IEnumerable
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
                new AnimalRegistrationRequestModel()
                {
                Name = "Мистер главный",
                Age = 2,
                RecommendationsForCare = "Мыть лапы тщательно",
                Breed = "Доберман",
                Size = 7,
                },
            };
        }
    }
}
