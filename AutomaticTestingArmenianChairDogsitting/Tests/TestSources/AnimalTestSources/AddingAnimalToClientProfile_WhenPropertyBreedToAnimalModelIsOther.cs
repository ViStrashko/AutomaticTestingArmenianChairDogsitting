using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.AnimalTestSources
{
    public class AddingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Бобик",
                Age = 5,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Другая",
                Size = 35,
                ClientId = 1,
            };
        }
    }
}
