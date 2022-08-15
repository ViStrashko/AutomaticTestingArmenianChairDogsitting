using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.AnimalNegativeTestSources
{
    public class GetAnimalByAnimalIdNegativeTest_WhenAnimalIdIsNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                0,
                new AnimalRegistrationRequestModel()
                {
                    Name = "Шарик",
                    Age = 1,
                    RecommendationsForCare = "Играть осторожно",
                    Breed = "Доберман",
                    Size = 5,
                }
            };
            yield return new object[]
            {
                -2,
                new AnimalRegistrationRequestModel()
                {
                    Name = "Лошарик",
                    Age = 2,
                    RecommendationsForCare = "Играть по кайфу",
                    Breed = "Доберман",
                    Size = 5,
                }
            };
        }
    }
}
