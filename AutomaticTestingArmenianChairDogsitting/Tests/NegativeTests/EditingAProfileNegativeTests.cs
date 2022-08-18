﻿using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.AnimalNegativeTestSources;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.SitterNegativeTestSources;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.NegativeTests
{
    public class EditingAProfileNegativeTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private ClientNegativeSteps _clientNegativeSteps;
        private SitterSteps _sitterSteps;
        private SitterNegativeSteps _sitterNegativeSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private ClientMappers _clientMappers;
        private SitterMappers _sitterMappers;
        private AnimalMappers _animalMappers;
        private string _adminToken;
        private string _clientToken;
        private string _sitterToken;
        private string _alienClientToken;
        private string _alienSitterToken;
        private int _clientId;
        private int _alienClientId;        
        private int _sitterId;
        private int _alienSitterId;
        private int _animalId;
        private ClientRegistrationRequestModel _clientModel;
        private ClientRegistrationRequestModel _alienClientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private SitterRegistrationRequestModel _alienSitterModel;
        private AnimalRegistrationRequestModel _animalModel;

        public EditingAProfileNegativeTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _clientNegativeSteps = new ClientNegativeSteps();
            _sitterSteps = new SitterSteps();
            _sitterNegativeSteps = new SitterNegativeSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _clientMappers = new ClientMappers();
            _sitterMappers = new SitterMappers();
            _animalMappers = new AnimalMappers();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.ClearAllDB();
        }

        [SetUp]
        public void SetUp()
        {
            _adminToken = _authorization.AuthorizeTest(new AuthRequestModel() { Email = Options.adminEmail, Password = Options.adminPassword });

            _clientModel = new ClientRegistrationRequestModel()
            {
                Name = "Вася",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "+79514125547",
                Address = "ул. Итальянская, дом. 10",
                Password = "12345678",
                Promocode = ""
            };
            _clientId = _clientSteps.RegisterClientTest(_clientModel);

            AuthRequestModel authClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _clientToken = _authorization.AuthorizeTest(authClientModel);

            _alienClientModel = new ClientRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Валерич",
                Email = "valera@gmail.com",
                Phone = "+79514147895",
                Address = "ул. Прямая, дом. 1",
                Password = "12234567",
                Promocode = ""
            };
            _alienClientId = _clientSteps.RegisterClientTest(_alienClientModel);

            AuthRequestModel authAlienClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_alienClientModel);
            _alienClientToken = _authorization.AuthorizeTest(authAlienClientModel);

            _sitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Phone = "+79514125547",
                Email = "pet@gmail.com",
                Password = "87654321",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }

            };
            _sitterId = _sitterSteps.RegisterSitterTest(_sitterModel);

            AuthRequestModel authSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_sitterModel);
            _sitterToken = _authorization.AuthorizeTest(authSitterModel);

            _alienSitterModel = new SitterRegistrationRequestModel()
            {
                Name = "Дима",
                LastName = "Васюкин",
                Phone = "+79511475511",
                Email = "vas@gmail.com",
                Password = "11122458",
                Age = 20,
                Experience = 1,
                Sex = 1,
                Description = "Description",
                PriceCatalog = new List<PriceCatalogRequestModel>()
                {
                    new PriceCatalogRequestModel() { Service = 1, Price = 500 },
                }
            };
            _alienSitterId = _sitterSteps.RegisterSitterTest(_alienSitterModel);

            AuthRequestModel authAlienSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_alienSitterModel);
            _alienSitterToken = _authorization.AuthorizeTest(authAlienSitterModel);

            _animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Бука",
                Age = 2,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _clientId,
            };
            _animalId = _clientSteps.RegisterAnimalToClientProfileTest(_animalModel, _clientToken);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        //Clients
        //Client endpoints
        [TestCaseSource(typeof(EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyIsEmpty_TestSource))]
        public void EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyIsEmpty_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientUpdateRequestModel clientUpdateModel)
        {
            _clientNegativeSteps.EditingClientsPropertyNegativeTest(_clientId, clientUpdateModel, _clientToken);
        }

        [TestCaseSource(typeof(EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneIncorrectFormat_TestSource))]
        public void EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneAndEmailIncorrectFormat_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientUpdateRequestModel clientUpdateModel)
        {
            _clientNegativeSteps.EditingClientsPropertyNegativeTest(_clientId, clientUpdateModel, _clientToken);
        }

        [TestCaseSource(typeof(EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneIsNotCorrectLength_TestSource))]
        public void EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneIsNotCorrectLength_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientUpdateRequestModel clientUpdateModel)
        {
            _clientNegativeSteps.EditingClientsPropertyNegativeTest(_clientId, clientUpdateModel, _clientToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void EditingClientProfileByClientNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusBadRequest(int id)
        {
            ClientUpdateRequestModel clientUpdateModel = _clientMappers.MappClientRegistrationRequestModelToClientUpdateRequestModel(_clientModel);
            _clientNegativeSteps.EditingClientProfileByClientIdWhenClientIdIsNotCorrectNegativeTest(id, clientUpdateModel, _clientToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void DeleteClientProfileByClientNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest(int id)
        {
            _clientNegativeSteps.DeleteClientProfileByClientIdWhenClientIdIsNotCorrectNegativeTest(id, _clientToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void GetClientProfileByClientIdNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest(int id)
        {
            _clientNegativeSteps.GetClientProfileByClientIdWhenClientIdIsNotCorrectNegativeTest(id, _clientToken);
        }

        //Animal endpoints
        [TestCaseSource(typeof(RegisterAnimalToClientProfileNegativeTest_WhenAnimalsPropertyEmptyAndNotCorrect_TestSource))]
        public void RegisterAnimalToClientProfileNegativeTest_WhenAnimalsPropertyEmptyAndNotCorrect_ShouldGetHttpStatusCodeUnprocessableEntity
            (AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.RegisterAnimalWhenAnimalsPropertyEmptyAndNotCorrectNegativeTest(model, _clientToken);
        }

        [TestCaseSource(typeof(RegisterAnimalToClientProfileNegativeTest_WhenClientIdIsNotCorrect_TestSource))]
        public void RegisterAnimalToClientProfileNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest
            (AnimalRegistrationRequestModel model)
        {
            _clientNegativeSteps.RegisterAnimalWhenClientIdIsNotCorrectNegativeTest(model, _clientToken);
        }

        [TestCaseSource(typeof(EditingAnimalToClientProfileNegativeTest_WhenAnimalsPropertyEmptyAndNotCorrect_TestSource))]
        public void EditingAnimalToClientProfileNegativeTest_WhenAnimalsPropertyEmptyAndNotCorrect_ShouldGetHttpStatusCodeUnprocessableEntity
            (AnimalUpdateRequestModel model)
        {
            _clientNegativeSteps.EditingAnimalWhenAnimalsPropertyEmptyAndNotCorrectNegativeTest(_animalId, model, _clientToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void EditingAnimalToClientProfileNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest
            (int id)
        {
            AnimalUpdateRequestModel animalUpdateModel = _animalMappers.MappAnimalRegistrationRequestModelToAnimalUpdateRequestModel(_animalModel);
            _clientNegativeSteps.EditingAnimalWhenAnimalIdIsNotCorrectNegativeTest(id, animalUpdateModel, _clientToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void DeleteAnimalToClientProfileNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest
            (int id)
        {
            _clientNegativeSteps.DeleteAnimalWhenAnimalIdIsNotCorrectNegativeTest(id, _clientToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void GetAnimalByAnimalIdNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeNotFound
            (int id)
        {
            _clientNegativeSteps.GetAnimalWhenAnimalIdIsNotCorrectNegativeTest(id, _clientToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void GetAnimalsByClientIdNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeNotFound
            (int id)
        {
            _clientNegativeSteps.GetAnimalsWhenClientIdIsNotCorrectNegativeTest(id, _clientToken);
        }

        //Sitters
        //Sitter endpoints
        [TestCaseSource(typeof(EditingSittersPrifileNegativeTest_WhenSitterModelIsNotCorrect_TestSource))]
        public void EditingSittersPrifileNegativeTest_WhenSitterModelIsNotCorrect_ShouldGetHttpStatusUnprocessableEntity
            (SitterUpdateRequestModel sitterUpdateModel)
        {
            _sitterNegativeSteps.EditingSitterProfileWhenSitterModelIsNotCorrectNegativeTest(sitterUpdateModel, _sitterToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void DeleteSittersPrifileNegativeTest_WhenSitterIdIsNotCorrect_ShouldGetHttpStatusBadRequest
            (int id)
        {
            _sitterNegativeSteps.DeleteSitterProfileWhenSitterIdIsNotCorrectNegativeTest(id, _sitterToken);
        }

        [TestCaseSource(typeof(ChangeSitterPasswordNegativeTest_WhenPasswordModelIsNotCorrect_TestSource))]
        public void ChangeSitterPasswordNegativeTest_WhenPasswordModelIsNotCorrect_ShouldGetHttpStatusUnprocessableEntity
            (ChangePasswordRequestModel passwordModel)
        {
            _sitterNegativeSteps.ChangeSitterPasswordWhenPasswordModelIsNotCorrectNegativeTest(passwordModel, _sitterToken);
        }

        [TestCaseSource(typeof(ChangeSitterPriceCatalogNegativeTest_WhenPriceCatalogModelIsNotCorrect_TestSource))]
        public void ChangeSitterPriceCatalogNegativeTest_WhenPriceCatalogModelIsNotCorrect_ShouldGetHttpStatusUnprocessableEntity
            (PriceCatalogUpdateModel priceCatalogModel)
        {
            _sitterNegativeSteps.ChangeSitterPriceCatalogWhenPriceCatalogModelIsNotCorrectNegativeTest(priceCatalogModel, _sitterToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void GetSitterProfileBySitterIdNegativeTest_WhenSitterIdIsNotCorrect_ShouldGetHttpStatusNotFound
            (int id)
        {
            _sitterNegativeSteps.GetSitterProfileWhenSitterIdIsNotCorrectNegativeTest(id, _sitterToken);
        }

        //All roles
        //Client endpoints
        [Test]
        public void GetClientProfileByClientIdByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetClientProfileByClientId()
        {
            _clientNegativeSteps.GetClientProfileByClientIdBySitterOrAlienClientNegativeTest(_clientId, _alienClientToken);
            _clientNegativeSteps.GetClientProfileByClientIdBySitterOrAlienClientNegativeTest(_clientId, _sitterToken);
            _clientNegativeSteps.GetClientProfileByClientIdByAnonimNegativeTest(_clientId, null);
        }

        [Test]
        public void GetClientProfilesByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetClientProfiles()
        {
            _clientNegativeSteps.GetClientProfilesByClientOrSitterNegativeTest(_clientToken);
            _clientNegativeSteps.GetClientProfilesByClientOrSitterNegativeTest(_sitterToken);
            _clientNegativeSteps.GetClientProfilesByAnonimNegativeTest(null);
        }

        [Test]
        public void AddingClientProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotAddingNewClientProfile()
        {
            _clientNegativeSteps.AddingClientProfileByClientOrAdminNegativeTest(_alienClientModel, _clientToken);
            _clientNegativeSteps.AddingClientProfileByClientOrAdminNegativeTest(_alienClientModel, _adminToken);
        }

        [Test]
        public void EditingClientProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotEditingClientProfile()
        {
            ClientUpdateRequestModel clientUpdateModel = _clientMappers.MappClientRegistrationRequestModelToClientUpdateRequestModel(_clientModel);
            _clientNegativeSteps.EditingClientProfileBySitterOrAlienClientOrAdminNegativeTest(_clientId, clientUpdateModel, _alienClientToken);
            _clientNegativeSteps.EditingClientProfileBySitterOrAlienClientOrAdminNegativeTest(_clientId, clientUpdateModel, _adminToken);
            _clientNegativeSteps.EditingClientProfileBySitterOrAlienClientOrAdminNegativeTest(_clientId, clientUpdateModel, _sitterToken);
            _clientNegativeSteps.EditingClientProfileByAnonimNegativeTest(_clientId, clientUpdateModel, null);
        }

        [Test]
        public void DeleteClientProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotDeleteClientProfile()
        {
            _clientNegativeSteps.DeleteClientProfileBySitterOrAlienClientNegativeTest(_clientId, _alienClientToken);
            _clientNegativeSteps.DeleteClientProfileBySitterOrAlienClientNegativeTest(_clientId, _sitterToken);
            _clientNegativeSteps.DeleteClientProfileByAnonimNegativeTest(_clientId, null);
        }

        [Test]
        public void RestoreClientProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotRestoreClientProfile()
        {
            _clientSteps.DeleteClientByIdTest(_clientId, _clientToken);
            _clientNegativeSteps.RestoreClientProfileBySitterOrClientNegativeTest(_clientId, _clientToken);
            _clientNegativeSteps.RestoreClientProfileBySitterOrClientNegativeTest(_clientId, _alienClientToken);
            _clientNegativeSteps.RestoreClientProfileBySitterOrClientNegativeTest(_clientId, _sitterToken);
            _clientNegativeSteps.RestoreClientProfileByAnonimNegativeTest(_clientId, null);
        }

        //Animal endpoints
        [Test]
        public void RegisterAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotRegisterAnimal()
        {
            _clientNegativeSteps.RegisterAnimalByAnonimNegativeTest(_animalModel, null);
            _animalModel.ClientId = Options.adminId;
            _clientNegativeSteps.RegisterAnimalBySitterOrAdminNegativeTest(_animalModel, _adminToken);
            _animalModel.ClientId = _sitterId;
            _clientNegativeSteps.RegisterAnimalBySitterOrAdminNegativeTest(_animalModel, _sitterToken);
        }

        [Test]
        public void EditingAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotEditingAnimal()
        {
            AnimalUpdateRequestModel animalUpdateModel = _animalMappers.MappAnimalRegistrationRequestModelToAnimalUpdateRequestModel
                (_animalModel);
            _clientNegativeSteps.EditingAnimalBySitterOrAdminNegativeTest(_animalId, animalUpdateModel, _alienClientToken);
            _clientNegativeSteps.EditingAnimalBySitterOrAdminNegativeTest(_animalId, animalUpdateModel, _adminToken);
            _clientNegativeSteps.EditingAnimalBySitterOrAdminNegativeTest(_animalId, animalUpdateModel, _sitterToken);
            _clientNegativeSteps.EditingAnimalByAnonimNegativeTest(_animalId, animalUpdateModel, null);
        }

        [Test]
        public void DeleteAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotDeleteAnimal()
        {
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminNegativeTest(_animalId, _alienClientToken);
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminNegativeTest(_animalId, _adminToken);
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminNegativeTest(_animalId, _sitterToken);
            _clientNegativeSteps.DeleteAnimalByAnonimNegativeTest(_animalId, null);
        }

        [Test]
        public void GetAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetAnimal()
        {
            _clientNegativeSteps.GetAnimalBySitterOrAdminNegativeTest(_animalId, _alienClientToken);
            _clientNegativeSteps.GetAnimalBySitterOrAdminNegativeTest(_animalId, _sitterToken);
            _clientNegativeSteps.GetAnimalByAnonimNegativeTest(_animalId, null);
        }

        [Test]
        public void GetAnimalsByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetAnimals()
        {
            _clientNegativeSteps.GetAnimalsBySitterOrAdminNegativeTest(_clientId, _alienClientToken);
            _clientNegativeSteps.GetAnimalsBySitterOrAdminNegativeTest(_clientId, _sitterToken);
            _clientNegativeSteps.GetAnimalsByAnonimNegativeTest(_clientId, null);
        }

        //Sitter endpoints
        [Test]
        public void EditingSitterProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotEditingSitterProfile()
        {
            SitterUpdateRequestModel sitterUpdateModel = _sitterMappers.MappSitterRegistrationModelToSitterUpdateRequestModel(_sitterModel);
            _sitterNegativeSteps.EditingSitterProfileByClientOrAdminOrAlienSitterNegativeTest(sitterUpdateModel, _alienSitterToken);
            _sitterNegativeSteps.EditingSitterProfileByClientOrAdminOrAlienSitterNegativeTest(sitterUpdateModel, _adminToken);
            _sitterNegativeSteps.EditingSitterProfileByClientOrAdminOrAlienSitterNegativeTest(sitterUpdateModel, _clientToken);
            _sitterNegativeSteps.EditingSitterProfileByAnonimNegativeTest(sitterUpdateModel, null);
        }

        [Test]
        public void DeleteSitterProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotDeleteSitterProfile()
        {
            _sitterNegativeSteps.DeleteSitterProfileByClientOrAlienSitterNegativeTest(_sitterId, _alienSitterToken);
            _sitterNegativeSteps.DeleteSitterProfileByClientOrAlienSitterNegativeTest(_sitterId, _clientToken);
            _sitterNegativeSteps.DeleteSitterProfileByAnonimNegativeTest(_sitterId, null);
        }

        [Test]
        public void ChangeSitterPasswordByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotChangeSitterProfile()
        {
            ChangePasswordRequestModel passwordModel = _sitterMappers.MappSitterRegistrationModelToChangePasswordRequestModel
                (_sitterModel, _sitterModel.Password);
            _sitterNegativeSteps.ChangeSitterPasswordByClientOrAdminOrAlienSitterNegativeTest(passwordModel, _alienSitterToken);
            _sitterNegativeSteps.ChangeSitterPasswordByClientOrAdminOrAlienSitterNegativeTest(passwordModel, _adminToken);
            _sitterNegativeSteps.ChangeSitterPasswordByClientOrAdminOrAlienSitterNegativeTest(passwordModel, _clientToken);
            _sitterNegativeSteps.ChangeSitterPasswordByAnonimNegativeTest(passwordModel, null);
        }

        [Test]
        public void ChangeSitterPriceCatalogByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotChangeSitterPriceCatalog()
        {
            PriceCatalogUpdateModel priceCatalogModel = new PriceCatalogUpdateModel();
            priceCatalogModel.PriceCatalog = _sitterModel.PriceCatalog;
            _sitterNegativeSteps.ChangeSitterPriceCatalogByClientOrAdminOrAlienSitterNegativeTest(priceCatalogModel, _alienSitterToken);
            _sitterNegativeSteps.ChangeSitterPriceCatalogByClientOrAdminOrAlienSitterNegativeTest(priceCatalogModel, _adminToken);
            _sitterNegativeSteps.ChangeSitterPriceCatalogByClientOrAdminOrAlienSitterNegativeTest(priceCatalogModel, _clientToken);
            _sitterNegativeSteps.ChangeSitterPriceCatalogByAnonimNegativeTest(priceCatalogModel, null);
        }

        [Test]
        public void RestoreSitterProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotRestoreSitterProfile()
        {
            _sitterSteps.DeleteSitterByIdTest(_sitterId, _sitterToken);
            _sitterNegativeSteps.RestoreSitterProfileBySitterOrClientNegativeTest(_sitterId, _sitterToken);
            _sitterNegativeSteps.RestoreSitterProfileBySitterOrClientNegativeTest(_sitterId, _alienSitterToken);
            _sitterNegativeSteps.RestoreSitterProfileBySitterOrClientNegativeTest(_sitterId, _clientToken);
            _sitterNegativeSteps.RestoreSitterProfileByAnonimNegativeTest(_sitterId, null);
        }

        //Admin
        [TestCase(-2)]
        [TestCase(0)]
        public void RestoreClientProfileNegativeTest_WhenClientIdIsNotCorrect_ShouldReturnBadRequest(int id)
        {
            _clientNegativeSteps.RestoreClientProfileWithNotCorrectIdTest(id, _adminToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void RestoreSitterProfileNegativeTest_WhenSitterIdIsNotCorrect_ShouldReturnBadRequest(int id)
        {
            _sitterNegativeSteps.RestoreSitterProfileWithNotCorrectIdNegativeTest(id, _adminToken);
        }
    }
}