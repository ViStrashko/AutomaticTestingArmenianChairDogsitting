using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.AnimalNegativeTestSources
{
    public class GetAnimalsByClientIdNegativeTest_WhenClientIdIsNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Лошарик",
                Age = 2,
                RecommendationsForCare = "Играть по кайфу",
                Breed = "Доберман",
                Size = 7,
            };
        }
    }
}
