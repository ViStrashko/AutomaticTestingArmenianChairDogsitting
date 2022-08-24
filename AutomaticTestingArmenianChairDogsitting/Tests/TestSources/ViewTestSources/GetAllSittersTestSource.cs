using AutomaticTestingArmenianChairDogsitting.Models.Request;
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
                    Password = "12444678",
                    Age = 20,
                    Experience = 2,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                    {
                        new PriceCatalogRequestModel() { Service = 1, Price = 5000 },
                        new PriceCatalogRequestModel() { Service = 2, Price = 3000 },
                        new PriceCatalogRequestModel() { Service = 4, Price = 500 },
                    }
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера2",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet2@gmail.com",
                    Password = "12345178",
                    Age = 20,
                    Experience = 3,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                    {
                        new PriceCatalogRequestModel() { Service = 1, Price = 6000 },
                        new PriceCatalogRequestModel() { Service = 2, Price = 5000 },
                        new PriceCatalogRequestModel() { Service = 3, Price = 1000 },
                        new PriceCatalogRequestModel() { Service = 4, Price = 550 },
                    }
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера3",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet3@gmail.com",
                    Password = "12345688",
                    Age = 20,
                    Experience = 1,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                    {
                        new PriceCatalogRequestModel() { Service = 3, Price = 850 },
                        new PriceCatalogRequestModel() { Service = 4, Price = 650 },
                    }
                },
                new SitterRegistrationRequestModel()
                {
                    Name = "Валера4",
                    LastName = "Пет",
                    Phone = "+79514125547",
                    Email = "pet4@gmail.com",
                    Password = "12345679",
                    Age = 20,
                    Experience = 3,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                    {
                        new PriceCatalogRequestModel() { Service = 1, Price = 4500 },
                        new PriceCatalogRequestModel() { Service = 2, Price = 2700 },
                        new PriceCatalogRequestModel() { Service = 3, Price = 900 },
                        new PriceCatalogRequestModel() { Service = 4, Price = 700 },
                    }
                }
            };
            yield return sitters;
        }
    }    
}
