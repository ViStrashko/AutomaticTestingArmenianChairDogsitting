using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSourses.ClientTestSourses;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class EditingAProfileTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private ClientMappers _clientMappers;
        private string _token;
        private int _clientId;
        private int _sitterId;
        private ClientRegistrationRequestModel _clientModel;


        public EditingAProfileTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _clientMappers = new ClientMappers();
            _clientModel = new ClientRegistrationRequestModel()
            {
                 Name = "Вася",
                 LastName = "Петров",
                 Email = "petrov@gmail.com",
                 Phone = "+79514125547",
                 Address = "ул. Итальянская, дом. 10",
                 Password = "12345678",
            };
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.AfterScenario();
        }

        [SetUp]
        public void SetUp()
        {
            _clientId = _clientSteps.RegisterClient(_clientModel);

            AuthRequestModel authModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _token = _authorization.Authorize(authModel);

        }
        [TearDown]
        public void TearDown()
        {
            _clearingTables.AfterScenario();
        }

        [TestCaseSource(typeof(EditingClientProfile_WhenClientModelIsCorrect_TestSours))]
        public void EditingClientProfile_WhenClientModelIsCorrect_ShouldEditingClientProfile(ClientUpdateRequestModel clientUpdateModel)
        {
            _clientSteps.UpdateClientById(_clientId, _token, clientUpdateModel);

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientUpdateRequestModelToClientAllInfoResponseModel(clientUpdateModel, _clientId);
            _clientSteps.GetAllInfoClientById(_clientId, _token, expectedClient);
        }

        [TestCaseSource(typeof(DeleteClientProfile_WhenClientModelIsCorrect_TestSours))]
        public void DeleteClientProfile_WhenClientIdIsCorrect_ShouldDeletingClientProfile(ClientAllInfoResponseModel expectedClient)
        {
            _clientSteps.DeleteClientById(_clientId, _token);

            _clientSteps.GetAllInfoClientById(_clientId, _token, expectedClient);
        }

        [Test]
        public void AddingAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldAddingAnimalToClientProfile()
        {
            AnimalRegistrationRequestModel animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _clientId,
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
            _clientSteps.GetAllInfoAnimalById(animalId, _token, expectedAnimal);

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
            _clientSteps.GetAnimalsByClientId(_clientId, _token, expectedAnimals);

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
            _clientSteps.GetAllInfoClientById(_clientId, _token, expectedClient);
        }

        [Test]
        public void AddingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldAddingAnimalToClientProfileWithPropertyBreedIsLarge()
        {
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
        public void DeleteSitterProfile_WhenSitterIdIsCorrect_ShouldDeletingSitterProfile()
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
                IsDeleted = true,
            };
            _sitterSteps.GetAllInfoSitterById(sitterId, token, expectedSitter);
        }
    }
}
