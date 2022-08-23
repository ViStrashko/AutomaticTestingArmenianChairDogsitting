using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class EditingSittersPrifileNegativeTest_WhenSitterModelIsNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            //Empty
            yield return new SitterUpdateRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "",
                Age = 0,
                Experience = -1,
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
                Name = "Vova5",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 0
            };
            //Incorrect phone format
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova6",
                LastName = "Blinov",
                Phone = "asdfghjklqw",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova7",
                LastName = "Blinov",
                Phone = "8951478154j",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova8",
                LastName = "Blinov",
                Phone = "871<>?!@#$%",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova9",
                LastName = "Blinov",
                Phone = "847;:&*^-.,",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova10",
                LastName = "Blinov",
                Phone = "asdfghjklqwq",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova11",
                LastName = "Blinov",
                Phone = "+7951478154j",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova12",
                LastName = "Blinov",
                Phone = "+771<>?!@#$%",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova13",
                LastName = "Blinov",
                Phone = "+747;:&*^-.,",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova14",
                LastName = "Blinov",
                Phone = "8123456789",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova15",
                LastName = "Blinov",
                Phone = "812345678901",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova16",
                LastName = "Blinov",
                Phone = "+7123456789",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova17",
                LastName = "Blinov",
                Phone = "+712345678901",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            //incorrect age
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova18",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = -1,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova19",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 13,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 1
            };
            //incorrect experience
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova20",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = -1,
                Description = "Ya Vova",
                Sex = 1
            };
            //Incorrect sex
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova21",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 3
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova22",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = -10
            };
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova23",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 2,
                Description = "Ya Vova",
                Sex = 10
            };
            //Incorrect difference between age and experience > 14
            yield return new SitterUpdateRequestModel()
            {
                Name = "Vova24",
                LastName = "Blinov",
                Phone = "81234567890",
                Age = 20,
                Experience = 7,
                Description = "Ya Vova",
                Sex = 1,
            };
        }
    }
}
