using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class EditingAProfileTests
    {
        private Authorizations _authorization = new Authorizations();
        private ClientSteps _clientSteps = new ClientSteps();
        private SitterSteps _sitterSteps = new SitterSteps();

        [Test]
        public void EditingClientProfile_WhenClientModelIsCorrect_ShouldEditingClientProfile()
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

            ClientUpdateRequestModel clientUpdateModel = new ClientUpdateRequestModel()
            {
                Name = clientModel.Name,
                LastName = clientModel.LastName,
                Email = clientModel.Email,
                Phone = "+79518741247",
                Address = clientModel.Address,
            };
            _clientSteps.UpdateClientById(clientId, token, clientUpdateModel);

            ClientAllInfoResponseModel expectedClient = new ClientAllInfoResponseModel()
            {
                Id = clientId,
                Name = clientUpdateModel.Name,
                LastName = clientUpdateModel.LastName,
                Phone = clientUpdateModel.Phone,
                Address = clientUpdateModel.Address,
                Email = clientUpdateModel.Email,
                RegistrationDate = DateTime.Now.Date,
                Dogs = null,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoClientById(clientId, token, expectedClient);
        }

        [Test]
        public void DeletingClientProfile_WhenClientIdIsCorrect_ShouldDeletingClientProfile()
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

            _clientSteps.DeleteClientById(clientId, token);

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
                IsDeleted = true,
            };
            _clientSteps.GetAllInfoClientById(clientId, token, expectedClient);
        }

        [Test]
        public void AddingAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldAddingAnimalToClientProfile()
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

            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = clientId,
            };
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            AnimalAllInfoResponseModel expectedAnimal = new AnimalAllInfoResponseModel()
            {
                Id = animalId,
                Name = animalModel.Name,
                Age = animalModel.Age,
                RecommendationsForCare = animalModel.RecommendationsForCare,
                Breed = animalModel.Breed,
                Size = animalModel.Size,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoAnimalById(animalId, token, expectedAnimal);

            ClientAnimalsResponseModels expectedAnimals = new ClientAnimalsResponseModels()
            {
                Dogs = new List<AnimalAllInfoResponseModel>
                {
                    new AnimalAllInfoResponseModel()
                    {
                        Id = animalId,
                        Name = animalModel.Name,
                        Age = animalModel.Age,
                        RecommendationsForCare = animalModel.RecommendationsForCare,
                        Breed = animalModel.Breed,
                        Size = animalModel.Size,
                        IsDeleted = false,
                    }
                }
            };
            _clientSteps.GetAnimalsByClientId(clientId, token, expectedAnimals);

            ClientAllInfoResponseModel expectedClient = new ClientAllInfoResponseModel()
            {
                Id = clientId,
                Name = clientModel.Name,
                LastName = clientModel.LastName,
                Phone = clientModel.Phone,
                Address = clientModel.Address,
                Email = clientModel.Email,
                RegistrationDate = DateTime.Now.Date,
                Dogs = new List<AnimalAllInfoResponseModel>
                {
                    new AnimalAllInfoResponseModel()
                    {
                        Id = animalId,
                        Name = animalModel.Name,
                        Age = animalModel.Age,
                        RecommendationsForCare = animalModel.RecommendationsForCare,
                        Breed = animalModel.Breed,
                        Size = animalModel.Size,
                        IsDeleted = false,
                    },
                },
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoClientById(clientId, token, expectedClient);
        }

        [Test]
        public void AddingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldAddingAnimalToClientProfileWithPropertyBreedIsLarge()
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

            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Бобик",
                Age = 5,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Другая",
                Size = 35,
                ClientId = clientId,
            };
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            AnimalAllInfoResponseModel expectedAnimal = new AnimalAllInfoResponseModel()
            {
                Id = animalId,
                Name = animalModel.Name,
                Age = animalModel.Age,
                RecommendationsForCare = animalModel.RecommendationsForCare,
                Breed = "Крупная",
                Size = animalModel.Size,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoAnimalById(animalId, token, expectedAnimal);

            ClientAnimalsResponseModels expectedAnimals = new ClientAnimalsResponseModels()
            {
                Dogs = new List<AnimalAllInfoResponseModel>
                {
                    new AnimalAllInfoResponseModel()
                    {
                        Id = animalId,
                        Name = animalModel.Name,
                        Age = animalModel.Age,
                        RecommendationsForCare = animalModel.RecommendationsForCare,
                        Breed = "Крупная",
                        Size = animalModel.Size,
                        IsDeleted = false,
                    }
                }
            };
            _clientSteps.GetAnimalsByClientId(clientId, token, expectedAnimals);

            ClientAllInfoResponseModel expectedClient = new ClientAllInfoResponseModel()
            {
                Id = clientId,
                Name = clientModel.Name,
                LastName = clientModel.LastName,
                Phone = clientModel.Phone,
                Address = clientModel.Address,
                Email = clientModel.Email,
                RegistrationDate = DateTime.Now.Date,
                Dogs = new List<AnimalAllInfoResponseModel>
                {
                    new AnimalAllInfoResponseModel()
                    {
                        Id = animalId,
                        Name = animalModel.Name,
                        Age = animalModel.Age,
                        RecommendationsForCare = animalModel.RecommendationsForCare,
                        Breed = "Крупная",
                        Size = animalModel.Size,
                        IsDeleted = false,
                    },
                },
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoClientById(clientId, token, expectedClient);
        }

        [Test]
        public void EditingAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldEditingAnimalToClientProfile()
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

            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = clientId,
            };
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            AnimalUpdateRequestModel animalUpdateModel = new AnimalUpdateRequestModel()
            {
                Name = animalModel.Name,
                Age = animalModel.Age,
                RecommendationsForCare = "Играть осторожно, мыть лапы тщательно",
                Breed = animalModel.Breed,
                Size = animalModel.Size,
            };
            _clientSteps.UpdateAnimalById(animalId, token, animalUpdateModel);

            AnimalAllInfoResponseModel expectedAnimal = new AnimalAllInfoResponseModel()
            {
                Id = animalId,
                Name = animalUpdateModel.Name,
                Age = animalUpdateModel.Age,
                RecommendationsForCare = animalUpdateModel.RecommendationsForCare,
                Breed = animalUpdateModel.Breed,
                Size = animalUpdateModel.Size,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoAnimalById(animalId, token, expectedAnimal);
        }

        [Test]
        public void EditingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldEditingAnimalToClientProfileWithPropertyBreedIsLarge()
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

            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно, мыть лапы тщательно",
                Breed = "Доберман",
                Size = 5,
                ClientId = clientId,
            };
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            AnimalUpdateRequestModel animalUpdateModel = new AnimalUpdateRequestModel()
            {
                Name = animalModel.Name,
                Age = animalModel.Age,
                RecommendationsForCare = animalModel.RecommendationsForCare,
                Breed = "Другая",
                Size = animalModel.Size,
            };
            _clientSteps.UpdateAnimalById(animalId, token, animalUpdateModel);

            AnimalAllInfoResponseModel expectedAnimal = new AnimalAllInfoResponseModel()
            {
                Id = animalId,
                Name = animalUpdateModel.Name,
                Age = animalUpdateModel.Age,
                RecommendationsForCare = animalUpdateModel.RecommendationsForCare,
                Breed = "Крупная",
                Size = animalUpdateModel.Size,
                IsDeleted = false,
            };
            _clientSteps.GetAllInfoAnimalById(animalId, token, expectedAnimal);
        }

        [Test]
        public void DeleteAnimalToClientProfile_WhenAnimalIdIsCorrect_ShouldDeleteAnimalToClientProfile()
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

            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = clientId,
            };
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            _clientSteps.DeleteAnimalById(animalId, token);

            AnimalAllInfoResponseModel expectedAnimal = new AnimalAllInfoResponseModel()
            {
                Id = animalId,
                Name = animalModel.Name,
                Age = animalModel.Age,
                RecommendationsForCare = animalModel.RecommendationsForCare,
                Breed = animalModel.Breed,
                Size = animalModel.Size,
                IsDeleted = true,
            };
            _clientSteps.GetAllInfoAnimalById(animalId, token, expectedAnimal);
        }

        [Test]
        public void EditingSitterProfile_WhenSitterModelIsCorrect_ShouldEditingSitterProfile()
        {
            SitterRegistrationRequestModel sitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Email = "pet@gmail.com",
                Age = 20,
                Description = "Description",
                Experience = 10,
                Sex = 1,
                Phone = "+79514125547",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel()
                    {
                        Service = 1,
                        Price = 500,
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

            SitterUpdateRequestModel sitterUpdateModel = new SitterUpdateRequestModel()
            {
                Name = sitterModel.Name,
                LastName = sitterModel.LastName,
                Email = sitterModel.Email,
                Age = sitterModel.Age,
                Sex = sitterModel.Sex,
                Experience = sitterModel.Experience,
                Description = sitterModel.Description,
                Phone = "+79518741247",
                PriceCatalog = new List<PriceCatalogUpdateRequestModel>()
                {
                    new PriceCatalogUpdateRequestModel()
                    {
                        Service = sitterModel.PriceCatalog[1].Service,
                        Price =  sitterModel.PriceCatalog[1].Price,
                    },
                },
            };
            _sitterSteps.UpdateSitterById(sitterId, token, sitterUpdateModel);

            SitterAllInfoResponseModel expectedSitter = new SitterAllInfoResponseModel()
            {
                Id = sitterId,
                Name = sitterUpdateModel.Name,
                LastName = sitterUpdateModel.LastName,
                Phone = sitterUpdateModel.Phone,
                Email = sitterUpdateModel.Email,
                Age= sitterUpdateModel.Age,
                Description = sitterUpdateModel.Description,
                Sex = sitterUpdateModel.Sex,
                Experience= sitterUpdateModel.Experience,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        SitterId = sitterId,
                        Service = sitterUpdateModel.PriceCatalog[1].Service,
                        Price =  sitterUpdateModel.PriceCatalog[1].Price,
                        IsDeleted = false,
                    },
                },
                IsDeleted  = false,
            };
            _sitterSteps.GetAllInfoSitterById(sitterId, token, expectedSitter);
        }

        [Test]
        public void DeletingSitterProfile_WhenSitterIdIsCorrect_ShouldDeletingSitterProfile()
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
                Password = "12345678"
            };
            int sitterId = _sitterSteps.RegisterSitter(sitterModel);

            AuthRequestModel authModel = new AuthRequestModel()
            {
                Email = sitterModel.Email,
                Password = sitterModel.Password,
            };
            string token = _authorization.Authorize(authModel);

            _sitterSteps.DeleteSitterById(sitterId, token);

            SitterAllInfoResponseModel expectedSitter = new SitterAllInfoResponseModel()
            {
                Id = sitterId,
                Name = sitterModel.Name,
                LastName = sitterModel.LastName,
                Email = sitterModel.Email,
                Phone = sitterModel.Phone,
                Age = sitterModel.Age,
                Description = sitterModel.Description,
                Experience= sitterModel.Experience,
                Sex= sitterModel.Sex,
                PriceCatalog = new List<PriceCatalogResponseModel>()
                {
                    new PriceCatalogResponseModel()
                    {
                        SitterId = sitterId,
                        Service = sitterModel.PriceCatalog[1].Service,
                        Price =  sitterModel.PriceCatalog[1].Price,
                        IsDeleted = false,
                    },
                },
                IsDeleted = false,
            };
            _sitterSteps.GetAllInfoSitterById(sitterId, token, expectedSitter);
        }
    }
}
