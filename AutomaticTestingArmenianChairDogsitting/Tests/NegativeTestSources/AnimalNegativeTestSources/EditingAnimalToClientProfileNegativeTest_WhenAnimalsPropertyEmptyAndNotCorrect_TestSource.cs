using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.AnimalNegativeTestSources
{
    public class EditingAnimalToClientProfileNegativeTest_WhenAnimalsPropertyEmptyAndNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик1",
                Age = 0,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик2",
                Age = 1,
                RecommendationsForCare = "",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик3",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "",
                Size = 5,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик4",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 0,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "",
                Age = 0,
                RecommendationsForCare = "",
                Breed = "",
                Size = 0,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик5",
                Age = -1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик6",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = -10,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик7",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 10,
            };
            yield return new AnimalRegistrationRequestModel()
            {
                Name = "Шарик8",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 6,
            };
        }
    }
}
