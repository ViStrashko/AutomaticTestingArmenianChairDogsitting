using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.AnimalTestSources
{
    public class EditingAnimalToClientProfile_WhenAnimalModelIsCorrect_TestSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно, мыть лапы тщательно",
                Breed = "Доберман",
                Size = 5,
            };
        }
    }
}
