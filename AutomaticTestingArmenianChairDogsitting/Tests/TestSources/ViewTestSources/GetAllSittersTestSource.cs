using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Collections;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ViewTestSources
{
    public class GetAllSittersByAnyRoleTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<SitterRegistrationRequestModel> sitters = new List<SitterRegistrationRequestModel>()
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера1",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet1@gmail.com",
                    Password = "12345678",
                    Age = 20,
                    Experience = 10,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера2",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet2@gmail.com",
                    Password = "12345678",
                    Age = 20,
                    Experience = 10,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера3",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet3@gmail.com",
                    Password = "12345678",
                    Age = 20,
                    Experience = 10,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера4",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet4@gmail.com",
                    Password = "12345678",
                    Age = 20,
                    Experience = 10,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                    {
                        new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                    }
                }
            };
            yield return sitters;
        }
    }
    public class GetAllInfoSitterTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet@gmail.com",
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
