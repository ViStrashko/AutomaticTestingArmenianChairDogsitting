using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.AnimalTestSources
{
    public class EditingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOtherAndAnimalModelIsCorrect_TestSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AnimalRegistrationRequestModel()
                {
                    Name = "Шарик",
                    Age = 1,
                    RecommendationsForCare = "Играть осторожно, мыть лапы тщательно",
                    Breed = "Доберман",
                    Size = 5,
                },
                new AnimalUpdateRequestModel()
                {
                    Name = "Шарик",
                    Age = 1,
                    RecommendationsForCare = "Играть осторожно, мыть лапы тщательно",
                    Breed = "Другая",
                    Size = 5,
                },
            };
        }
    }
}
