using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class SitterCreationNegativeTest_WhenSittersPropertyIsEmptyOrIsNotCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            //Empty
            yield return new SitterRegistrationRequestModel()
            {
                Name = "",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша1",
                LastName = "",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша2",
                LastName = "Пет",
                Phone = "",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша3",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша4",
                LastName = "Пет1",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша5",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 0,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша6",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 0,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };           
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша7",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 0, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша8",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 0 },
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
                Experience = -1,
                Sex = 0,
                Description = "",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 0, Price = 0 },
                }
            };
            //Incorrect age
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша9",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = -1,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша10",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 13,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            //Incorrect experience
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша11",
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
            //Incorrect sex
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша12",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 3,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша13",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 10,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша14",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = -10,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            //Incorrect service
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша15",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 5, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша16",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 10, Price = 500 },
                }
            };
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша17",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = -10, Price = 500 },
                }
            };
            //Incorrect price
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша18",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = -1 },
                }
            };
            //Incorrect difference between age and experience > 14
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша19",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "12345678",
                Age = 20,
                Experience = 7,
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
