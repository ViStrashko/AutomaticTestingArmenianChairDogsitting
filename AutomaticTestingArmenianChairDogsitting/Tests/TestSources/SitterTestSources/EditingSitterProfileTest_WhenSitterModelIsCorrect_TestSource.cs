using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ClientTestSources
{
    public class EditingSitterProfileTest_WhenSitterModelIsCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SitterUpdateRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Phone = "+79514125547",
                Age = 20,
                Experience = 4,
                Sex = 1,
                Description = "Очень люблю собак",
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Phone = "+79514125547",
                Age = 20,
                Experience = 2,
                Sex = 1,
                Description = "Очень люблю собак, особенно лохматых",
            };
        }
    }
}