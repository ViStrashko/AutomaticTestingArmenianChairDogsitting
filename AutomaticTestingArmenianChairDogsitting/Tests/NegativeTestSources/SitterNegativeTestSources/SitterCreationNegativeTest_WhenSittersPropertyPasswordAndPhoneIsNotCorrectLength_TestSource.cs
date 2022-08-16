using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class SitterCreationNegativeTest_WhenSittersPropertyPasswordAndPhoneIsNotCorrectLength_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Миша1",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "1234567",
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
                Name = "Миша2",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet0@gmail.com",
                Password = "1",
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
                Name = "Миша3",
                LastName = "Пет",
                Phone = "+795141255471",
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
                Name = "Миша4",
                LastName = "Пет",
                Phone = "+7951412554",
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
                Name = "Миша5",
                LastName = "Пет",
                Phone = "8951412654",
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
                Name = "Миша6",
                LastName = "Пет",
                Phone = "895141265471",
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
