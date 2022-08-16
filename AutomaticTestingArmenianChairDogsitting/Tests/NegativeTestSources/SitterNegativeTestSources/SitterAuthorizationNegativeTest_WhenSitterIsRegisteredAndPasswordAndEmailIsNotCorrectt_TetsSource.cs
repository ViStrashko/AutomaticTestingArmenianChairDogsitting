using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources
{
    public class SitterAuthorizationNegativeTest_WhenSitterIsRegisteredAndPasswordAndEmailIsNotCorrectt_TetsSource : IEnumerable
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
                    Experience = 10,
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
                    Password = "",
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
                    Experience = 10,
                    Sex = 1,
                    Description = "Description",
                    PriceCatalog = new List<PriceCatalogRequestModel>()
                    {
                        new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                    }
                },
                new AuthRequestModel()
                {
                    Email = "",
                    Password = "12345678",
                }
            };
            yield return new object[]
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Миша3",
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
                },
                new AuthRequestModel()
                {
                    Email = "",
                    Password = "",
                }
            };
            yield return new object[]
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Миша4",
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
                },
                new AuthRequestModel()
                {
                    Email = "pet0@gmail.com",
                    Password = "1",
                }
            };
            yield return new object[]
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Миша5",
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
                },
                new AuthRequestModel()
                {
                    Email = "pet0@gmail.com",
                    Password = "1234567",
                }
            };
            yield return new object[]
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Миша6",
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
                },
                new AuthRequestModel()
                {
                    Email = "pet0gmail.com",
                    Password = "12345678",
                }
            };
            yield return new object[]
            {
                new SitterRegistrationRequestModel()
                {
                    Name = "Миша7",
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
                },
                new AuthRequestModel()
                {
                    Email = "pet0@gmail",
                    Password = "12345678",
                }
            };
        }
    }
}
