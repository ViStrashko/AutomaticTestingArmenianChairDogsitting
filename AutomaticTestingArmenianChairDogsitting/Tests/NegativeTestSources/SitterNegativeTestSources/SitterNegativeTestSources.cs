using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class SitterRegistrationWrongModelNegativeTestSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SitterRegistrationRequestModel() 
            {
                Name = "",
                LastName = "Пет1",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description"
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description"
            }; 
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет1",
                Phone = "",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description"
            }; 
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет1",
                Phone = "+79514125547",
                Email = "",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description"
            }; 
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет1",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description"
            }; 
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет1",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 0,
                Experience = 10,
                Sex = 1,
                Description = "Description"
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет1",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = -1,
                Sex = 1,
                Description = "Description"
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет1",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 0,
                Description = "Description"
            }; 
            yield return new SitterRegistrationRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description"
            };
        }
    }
}
