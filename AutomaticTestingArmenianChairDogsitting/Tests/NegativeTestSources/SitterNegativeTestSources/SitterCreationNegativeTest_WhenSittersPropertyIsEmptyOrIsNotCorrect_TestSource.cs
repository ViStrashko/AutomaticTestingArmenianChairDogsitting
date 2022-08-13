using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Collections;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class SitterCreationNegativeTest_WhenSittersPropertyIsEmptyOrIsNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SitterRegistrationRequestModel()
            {
                Name = "",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет1",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 0,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 0,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 0,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "",
                LastName = "",
                Phone = "",
                Email = "",
                Password = "",
                Age = 0,
                Experience = 0,
                Sex = 0,
                Description = "",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = -1,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = -1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 3,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 10,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = -10,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 10,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
        }
    }
}
