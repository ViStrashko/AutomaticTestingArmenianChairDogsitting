using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.AnimalNegativeTestSources
{
    public class EditingAnimalToClientProfileNegativeTest_WhenAnimalsPropertyEmptyAndNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new AnimalUpdateRequestModel()
            {
                Name = "",
                Age = 2,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Бука1",
                Age = 0,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Бука2",
                Age = 2,
                RecommendationsForCare = "",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Бука3",
                Age = 2,
                RecommendationsForCare = "Играть осторожно",
                Breed = "",
                Size = 5,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Бука4",
                Age = 2,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 0,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "",
                Age = 0,
                RecommendationsForCare = "",
                Breed = "",
                Size = 0,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Бука5",
                Age = -1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Бука6",
                Age = 2,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = -10,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Бука7",
                Age = 2,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 10,
            };
            yield return new AnimalUpdateRequestModel()
            {
                Name = "Бука8",
                Age = 2,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 6,
            };
        }
    }
}
