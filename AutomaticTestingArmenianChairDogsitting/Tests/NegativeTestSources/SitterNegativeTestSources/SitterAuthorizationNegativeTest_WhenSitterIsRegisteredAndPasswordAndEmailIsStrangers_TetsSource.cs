using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class SitterAuthorizationNegativeTest_WhenSitterIsRegisteredAndPasswordAndEmailIsStrangers_TetsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Миша1",
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
                },
                new AuthRequestModel()
                {
                    Email = "pet0@gmail.com",
                    Password = "12345677",
                }
            };
            yield return new object[]
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Миша2",
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
                },
                new AuthRequestModel()
                {
                    Email = "smirnov@gmail.com",
                    Password = "12345678",
                }
            };
        }
    }
}
        

