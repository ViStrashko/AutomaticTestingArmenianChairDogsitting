using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class RegistrationTests
    {
        private Authorizations _authorization = new Authorizations();
        private ClientSteps _clientSteps = new ClientSteps();
        private SitterSteps _sitterSteps = new SitterSteps();

        [Test]
        public void ClientCreation_WhenClientModelIsCorrect_ShouldCreateClient()
        {
            ClientRegisrationRequestModel clientModel = new ClientRegisrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "12345678",
            };
            int clientId = _clientSteps.RegisterClient(clientModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = clientModel.Email,
                Password = clientModel.Password,
            };
            string token = _authorization.Authorize(authModel);

            ClientAllInfoResponseModel expectedClient = new ClientAllInfoResponseModel()
            {
                Id = clientId,
                Name = clientModel.Name,
                LastName = clientModel.LastName,
                Phone = clientModel.Phone,
                Address = clientModel.Address,
                Email = clientModel.Email,
                RegistrationDate = DateTime.Now.Date,
                Dogs = null,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoClientById(clientId, token, expectedClient);
        }

        [Test]
        public void SitterCreation_WhenSitterModelIsCorrect_ShouldCreateSitter()
        {
            SitterRegistrationRequestModel sitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Email = "pet@gmail.com",
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
            int sitterId = _sitterSteps.RegisterSitter(sitterModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = sitterModel.Email,
                Password = sitterModel.Password,
            };
            string token = _authorization.Authorize(authModel);

            SitterAllInfoResponseModel expectedSitter = new SitterAllInfoResponseModel()
            {
                Id = sitterId,
                Name = sitterModel.Name,
                LastName = sitterModel.LastName,
                Phone = sitterModel.Phone,
                Email = sitterModel.Email,
                Age = sitterModel.Age,
                Description = sitterModel.Description,
                Experience = sitterModel.Experience,
                Sex = sitterModel.Sex,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel.PriceCatalog[1].Service,
                        Price = sitterModel.PriceCatalog[1].Price,
                        SitterId = sitterId,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel.PriceCatalog[2].Service,
                        Price = sitterModel.PriceCatalog[2].Price,
                        SitterId = sitterId,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel.PriceCatalog[3].Service,
                        Price = sitterModel.PriceCatalog[3].Price,
                        SitterId = sitterId,
                        IsDeleted = false,
                    },
                    new PriceCatalogResponseModel()
                    {
                        Service = sitterModel.PriceCatalog[4].Service,
                        Price = sitterModel.PriceCatalog[4].Price,
                        SitterId = sitterId,
                        IsDeleted = false,
                    },
                },
                IsDeleted = false,
            };
            _sitterSteps.GetAllInfoSitterById(sitterId, token, expectedSitter);
        }
    }
}
