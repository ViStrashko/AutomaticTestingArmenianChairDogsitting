using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class EditSittersPrifileIncorrectDataNegativeTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SitterUpdateRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "",
                Age = 0,
                Experience = -2,
                Description = "",
                Sex = -1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "7890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "+aabcdefghij",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = -2,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 200,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = -2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 0
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = -1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 10
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 30,
                Experience = 28,
                Description = "Ya Vova",
                Sex = 1
            };
        }
    }
}
