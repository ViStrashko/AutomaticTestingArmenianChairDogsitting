using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class ViewTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;


        public ViewTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
        }

        public void GetAllSittesTest_ByAllRoles_ShouldReturnAllSitters()
        {
            SitterRegistrationRequestModel sitterModel0 = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Email = "pet0@gmail.com",
                Phone = "+79514125547",
                Age = 20,
                Description = "Description",
                Experience = 10,
                Sex = 1,
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Service = 1,
                        Price = 500,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 2,
                        Price = 700,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 3,
                        Price = 1000,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 4,
                        Price = 1500,
                    },
                },
                Password = "12345678",
            };
            int sitterId0 = _sitterSteps.RegisterSitter(sitterModel0);
            SitterRegistrationRequestModel sitterModel1 = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Email = "pet1@gmail.com",
                Phone = "+79514125547",
                Age = 20,
                Description = "Description",
                Experience = 10,
                Sex = 1,
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Service = 1,
                        Price = 500,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 2,
                        Price = 700,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 3,
                        Price = 1000,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 4,
                        Price = 1500,
                    },
                },
                Password = "12345678",
            };
            int sitterId1 = _sitterSteps.RegisterSitter(sitterModel1);
            SitterRegistrationRequestModel sitterModel2 = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Email = "pet2@gmail.com",
                Phone = "+79514125547",
                Age = 20,
                Description = "Description",
                Experience = 10,
                Sex = 1,
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Service = 1,
                        Price = 500,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 2,
                        Price = 700,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 3,
                        Price = 1000,
                    },
                    new PriceCatalogRequestModel()
                    {
                        Service = 4,
                        Price = 1500,
                    },
                },
                Password = "12345678",
            };
            int sitterId2 = _sitterSteps.RegisterSitter(sitterModel2);
            ClientRegistrationRequestModel clientModel = new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "12345678",
            };
            int clientId = _clientSteps.RegisterClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel();
            string tokenNonAuthorized = _authorization.Authorize(authModel);

            authModel.Email = sitterModel0.Email;
            authModel.Password = sitterModel0.Password;
            string tokenSitter0 = _authorization.Authorize(authModel);
            
            authModel.Email = sitterModel1.Email;
            authModel.Password = sitterModel1.Password;
            string tokenSitter1 = _authorization.Authorize(authModel);

            authModel.Email = clientModel.Email;
            authModel.Password = clientModel.Password;
            string tokenClient = _authorization.Authorize(authModel);

            List<SitterAllInfoResponseModel> expectedAllSitters = new List<SitterAllInfoResponseModel>() 
            {
                new SitterAllInfoResponseModel{
                Id = sitterId0,
                Name = sitterModel0.Name,
                LastName = sitterModel0.LastName,
                Phone = sitterModel0.Phone,
                Email = sitterModel0.Email,
                Age = sitterModel0.Age,
                Description = sitterModel0.Description,
                Experience = sitterModel0.Experience,
                Sex = sitterModel0.Sex,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel0.PriceCatalog[1].Service,
                        Price = sitterModel0.PriceCatalog[1].Price,
                        SitterId = sitterId0,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel0.PriceCatalog[2].Service,
                        Price = sitterModel0.PriceCatalog[2].Price,
                        SitterId = sitterId0,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel0.PriceCatalog[3].Service,
                        Price = sitterModel0.PriceCatalog[3].Price,
                        SitterId = sitterId0,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel0.PriceCatalog[4].Service,
                        Price = sitterModel0.PriceCatalog[4].Price,
                        SitterId = sitterId0,
                        IsDeleted = false,
                    },
                },
                IsDeleted = false,
            },
                new SitterAllInfoResponseModel{
                Id = sitterId1,
                Name = sitterModel1.Name,
                LastName = sitterModel1.LastName,
                Phone = sitterModel1.Phone,
                Email = sitterModel1.Email,
                Age = sitterModel1.Age,
                Description = sitterModel1.Description,
                Experience = sitterModel1.Experience,
                Sex = sitterModel1.Sex,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel1.PriceCatalog[1].Service,
                        Price = sitterModel1.PriceCatalog[1].Price,
                        SitterId = sitterId1,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel1.PriceCatalog[2].Service,
                        Price = sitterModel1.PriceCatalog[2].Price,
                        SitterId = sitterId1,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel1.PriceCatalog[3].Service,
                        Price = sitterModel1.PriceCatalog[3].Price,
                        SitterId = sitterId1,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel1.PriceCatalog[4].Service,
                        Price = sitterModel1.PriceCatalog[4].Price,
                        SitterId = sitterId1,
                        IsDeleted = false,
                    },
                },
                IsDeleted = false,
            },
                new SitterAllInfoResponseModel{
                Id = sitterId2,
                Name = sitterModel2.Name,
                LastName = sitterModel2.LastName,
                Phone = sitterModel2.Phone,
                Email = sitterModel2.Email,
                Age = sitterModel2.Age,
                Description = sitterModel2.Description,
                Experience = sitterModel2.Experience,
                Sex = sitterModel2.Sex,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel2.PriceCatalog[1].Service,
                        Price = sitterModel2.PriceCatalog[1].Price,
                        SitterId = sitterId2,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel2.PriceCatalog[2].Service,
                        Price = sitterModel2.PriceCatalog[2].Price,
                        SitterId = sitterId2,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel2.PriceCatalog[3].Service,
                        Price = sitterModel2.PriceCatalog[3].Price,
                        SitterId = sitterId2,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel2.PriceCatalog[4].Service,
                        Price = sitterModel2.PriceCatalog[4].Price,
                        SitterId = sitterId2,
                        IsDeleted = false,
                    },
                },
                IsDeleted = false,
            }
            };

            _sitterSteps.GetAllInfoAllSitters(tokenNonAuthorized, expectedAllSitters);
            _sitterSteps.GetAllInfoAllSitters(tokenSitter0, expectedAllSitters);
            _sitterSteps.GetAllInfoAllSitters(tokenSitter1, expectedAllSitters);
            _sitterSteps.GetAllInfoAllSitters(tokenClient, expectedAllSitters);
        }
    }
}
