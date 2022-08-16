using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class EditingSittersPrifileNegativeTest_WhenSitterModelIsNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SitterUpdateRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "",
                Age = 0,
                Experience = 0,
                Description = "",
                Sex = 0
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
                Name = "Vova1",
                LastName = "",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova2",
                LastName = "Blinov",
                Phone = "",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova3",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 0,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova4",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 0,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova5",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova6",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 0
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova7",
                LastName = "Blinov",
                Phone = "asdfghjklqw",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova8",
                LastName = "Blinov",
                Phone = "8951478154j",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova9",
                LastName = "Blinov",
                Phone = "871<>?!@#$%",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova10",
                LastName = "Blinov",
                Phone = "847;:&*^-.,",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova11",
                LastName = "Blinov",
                Phone = "8123456789",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova12",
                LastName = "Blinov",
                Phone = "812345678901",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova13",
                LastName = "Blinov",
                Phone = "+7951147548",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova14",
                LastName = "Blinov",
                Phone = "+795114754847",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova15",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = -1,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova16",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = -1,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova17",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 3
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova18",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = -10
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova19",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 10
            };
        }
    }
}
