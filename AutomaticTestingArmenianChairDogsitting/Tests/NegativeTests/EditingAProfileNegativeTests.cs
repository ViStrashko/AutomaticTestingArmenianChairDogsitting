using NUnit.Framework;
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
            _adminToken = _authorization.AuthorizeTest(new AuthRequestModel() 
            { Email = Options.adminEmail, Password = Options.adminPassword });
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
                    new PriceCatalogRequestModel() { Service = 1, Price = 4500 },
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
                    new PriceCatalogRequestModel() { Service = 1, Price = 5000 },
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

        //Client
        //Client endpoints
        [TestCaseSource(typeof(EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyIsEmpty_TestSource))]
        public void EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyIsEmpty_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientUpdateRequestModel clientUpdateModel)
        {
            _clientNegativeSteps.EditingClientsPropertyNegativeTest(clientUpdateModel, _clientToken);
        }

        [TestCaseSource(typeof(EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneIncorrectFormat_TestSource))]
        public void EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneAndEmailIncorrectFormat_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientUpdateRequestModel clientUpdateModel)
        {
            _clientNegativeSteps.EditingClientsPropertyNegativeTest(clientUpdateModel, _clientToken);
        }

        [TestCaseSource(typeof(EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneIsNotCorrectLength_TestSource))]
        public void EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneIsNotCorrectLength_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientUpdateRequestModel clientUpdateModel)
        {
            _clientNegativeSteps.EditingClientsPropertyNegativeTest(clientUpdateModel, _clientToken);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void GetClientProfileByClientIdNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest(int id)
        {
            _clientNegativeSteps.GetClientProfileByClientIdWhenClientIdIsNotCorrectNegativeTest(id, _clientToken);
        }

        [TestCaseSource(typeof(ChangeClientPasswordNegativeTest_WhenPasswordModelIsNotCorrect_TestSource))]
        public void ChangeClientPasswordNegativeTest_WhenPasswordModelIsNotCorrect_ShouldGetHttpStatusUnprocessableEntity
            (ChangePasswordRequestModel passwordModel)
        {
            _clientNegativeSteps.ChangeClientPasswordWhenPasswordModelIsNotCorrectNegativeTest(passwordModel, _sitterToken);
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

        [TestCase(-2)]
        [TestCase(0)]
        public void RestoreAnimalByAnimalIdNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest
            (int id)
        {
            _clientNegativeSteps.RestoreAnimalWhenAnimalIdIsNotCorrectNegativeTest(id, _clientToken);
        }

        //Sitter
        //Sitter endpoints
        [TestCaseSource(typeof(EditingSittersPrifileNegativeTest_WhenSitterModelIsNotCorrect_TestSource))]
        public void EditingSittersPrifileNegativeTest_WhenSitterModelIsNotCorrect_ShouldGetHttpStatusUnprocessableEntity
            (SitterUpdateRequestModel sitterUpdateModel)
        {
            _sitterNegativeSteps.EditingSitterProfileWhenSitterModelIsNotCorrectNegativeTest(sitterUpdateModel, _sitterToken);
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
            _clientNegativeSteps.GetClientProfileByClientIdBySitterOrAlienClientOrAnonimNegativeTest(_clientId, _alienClientToken);
            _clientNegativeSteps.GetClientProfileByClientIdBySitterOrAlienClientOrAnonimNegativeTest(_clientId, _sitterToken);
            _clientNegativeSteps.GetClientProfileByClientIdBySitterOrAlienClientOrAnonimNegativeTest(_clientId, null);
        }

        [Test]
        public void GetClientProfilesByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetClientProfiles()
        {
            _clientNegativeSteps.GetClientProfilesByClientOrSitterOrAnonimNegativeTest(_clientToken);
            _clientNegativeSteps.GetClientProfilesByClientOrSitterOrAnonimNegativeTest(_sitterToken);
            _clientNegativeSteps.GetClientProfilesByClientOrSitterOrAnonimNegativeTest(null);
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
            _clientNegativeSteps.EditingClientProfileBySitterOrAdminOrAnonimNegativeTest(clientUpdateModel, _adminToken);
            _clientNegativeSteps.EditingClientProfileBySitterOrAdminOrAnonimNegativeTest(clientUpdateModel, _sitterToken);
            _clientNegativeSteps.EditingClientProfileBySitterOrAdminOrAnonimNegativeTest(clientUpdateModel, null);
        }

        [Test]
        public void DeleteClientProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotDeleteClientProfile()
        {
            _clientNegativeSteps.DeleteClientProfileBySitterOrAnonimNegativeTest(_sitterToken);
            _clientNegativeSteps.DeleteClientProfileBySitterOrAnonimNegativeTest(null);
        }

        [Test]
        public void RestoreClientProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotRestoreClientProfile()
        {
            _clientSteps.DeleteClientTest(_clientToken);
            _clientNegativeSteps.RestoreClientProfileBySitterOrClientOrAnonimNegativeTest(_clientId, _clientToken);
            _clientNegativeSteps.RestoreClientProfileBySitterOrClientOrAnonimNegativeTest(_clientId, _alienClientToken);
            _clientNegativeSteps.RestoreClientProfileBySitterOrClientOrAnonimNegativeTest(_clientId, _sitterToken);
            _clientNegativeSteps.RestoreClientProfileBySitterOrClientOrAnonimNegativeTest(_clientId, null);
        }

        [Test]
        public void ChangeClientPasswordByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotChangeClientPassword()
        {
            ChangePasswordRequestModel passwordModel = _clientMappers.MappClientRegistrationModelToChangePasswordRequestModel
                (_clientModel, _clientModel.Password);
            _clientNegativeSteps.ChangeClientPasswordBySitterOrAdminOrAnonimNegativeTest(passwordModel, _sitterToken);
            _clientNegativeSteps.ChangeClientPasswordBySitterOrAdminOrAnonimNegativeTest(passwordModel, _adminToken);
            _clientNegativeSteps.ChangeClientPasswordBySitterOrAdminOrAnonimNegativeTest(passwordModel, null);
        }

        //Animal endpoints
        [Test]
        public void RegisterAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotRegisterAnimal()
        {
            _clientNegativeSteps.RegisterAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalModel, null);
            _animalModel.ClientId = Options.adminId;
            _clientNegativeSteps.RegisterAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalModel, _adminToken);
            _animalModel.ClientId = _sitterId;
            _clientNegativeSteps.RegisterAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalModel, _sitterToken);
            _animalModel.ClientId = _alienClientId;
            _clientNegativeSteps.RegisterAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalModel, _alienClientToken);
        }

        [Test]
        public void EditingAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotEditingAnimal()
        {
            AnimalUpdateRequestModel animalUpdateModel = _animalMappers.MappAnimalRegistrationRequestModelToAnimalUpdateRequestModel
                (_animalModel);
            _clientNegativeSteps.EditingAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalId, animalUpdateModel, _alienClientToken);
            _clientNegativeSteps.EditingAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalId, animalUpdateModel, _adminToken);
            _clientNegativeSteps.EditingAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalId, animalUpdateModel, _sitterToken);
            _clientNegativeSteps.EditingAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalId, animalUpdateModel, null);
        }

        [Test]
        public void DeleteAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotDeleteAnimal()
        {
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalId, _alienClientToken);
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalId, _adminToken);
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalId, _sitterToken);
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminOrAlienClientOrAnonimNegativeTest(_animalId, null);
        }

        [Test]
        public void GetAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetAnimal()
        {
            _clientNegativeSteps.GetAnimalBySitterOrAlienClientOrAnonimNegativeTest(_animalId, _alienClientToken);
            _clientNegativeSteps.GetAnimalBySitterOrAlienClientOrAnonimNegativeTest(_animalId, _sitterToken);
            _clientNegativeSteps.GetAnimalBySitterOrAlienClientOrAnonimNegativeTest(_animalId, null);
        }

        [Test]
        public void GetAnimalsByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetAnimals()
        {
            _clientNegativeSteps.GetAnimalsBySitterOrAlienClientOrAnonimNegativeTest(_clientId, _alienClientToken);
            _clientNegativeSteps.GetAnimalsBySitterOrAlienClientOrAnonimNegativeTest(_clientId, _sitterToken);
            _clientNegativeSteps.GetAnimalsBySitterOrAlienClientOrAnonimNegativeTest(_clientId, null);
        }

        [Test]
        public void RestorreAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotRestoreAnimals()
        {
            _clientNegativeSteps.RestoreAnimalBySitterOrAlienClientOrAnonimOrAdminNegativeTest(_clientId, _adminToken);
            _clientNegativeSteps.RestoreAnimalBySitterOrAlienClientOrAnonimOrAdminNegativeTest(_clientId, _alienClientToken);
            _clientNegativeSteps.RestoreAnimalBySitterOrAlienClientOrAnonimOrAdminNegativeTest(_clientId, _sitterToken);
            _clientNegativeSteps.RestoreAnimalBySitterOrAlienClientOrAnonimOrAdminNegativeTest(_clientId, null);
        }

        //Sitter endpoints
        [Test]
        public void EditingSitterProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotEditingSitterProfile()
        {
            SitterUpdateRequestModel sitterUpdateModel = _sitterMappers.MappSitterRegistrationModelToSitterUpdateRequestModel(_sitterModel);
            _sitterNegativeSteps.EditingSitterProfileByClientOrAdminOrAnonimNegativeTest(sitterUpdateModel, _adminToken);
            _sitterNegativeSteps.EditingSitterProfileByClientOrAdminOrAnonimNegativeTest(sitterUpdateModel, _clientToken);
            _sitterNegativeSteps.EditingSitterProfileByClientOrAdminOrAnonimNegativeTest(sitterUpdateModel, null);
        }

        [Test]
        public void DeleteSitterProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotDeleteSitterProfile()
        {
            _sitterNegativeSteps.DeleteSitterProfileByClientOrAnonimNegativeTest(_clientToken);
            _sitterNegativeSteps.DeleteSitterProfileByClientOrAnonimNegativeTest(null);
        }

        [Test]
        public void ChangeSitterPasswordByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotChangeSitterPassword()
        {
            ChangePasswordRequestModel passwordModel = _sitterMappers.MappSitterRegistrationModelToChangePasswordRequestModel
                (_sitterModel, _sitterModel.Password);
            _sitterNegativeSteps.ChangeSitterPasswordByClientOrAdminOrAnonimNegativeTest(passwordModel, _adminToken);
            _sitterNegativeSteps.ChangeSitterPasswordByClientOrAdminOrAnonimNegativeTest(passwordModel, _clientToken);
            _sitterNegativeSteps.ChangeSitterPasswordByClientOrAdminOrAnonimNegativeTest(passwordModel, null);
        }

        [Test]
        public void ChangeSitterPriceCatalogByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotChangeSitterPriceCatalog()
        {
            PriceCatalogUpdateModel priceCatalogModel = new PriceCatalogUpdateModel();
            priceCatalogModel.PriceCatalog = _sitterModel.PriceCatalog;
            _sitterNegativeSteps.ChangeSitterPriceCatalogByClientOrAdminOrAnonimNegativeTest(priceCatalogModel, _adminToken);
            _sitterNegativeSteps.ChangeSitterPriceCatalogByClientOrAdminOrAnonimNegativeTest(priceCatalogModel, _clientToken);
            _sitterNegativeSteps.ChangeSitterPriceCatalogByClientOrAdminOrAnonimNegativeTest(priceCatalogModel, null);
        }

        [Test]
        public void RestoreSitterProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotRestoreSitterProfile()
        {
            _sitterSteps.DeleteSitterTest(_sitterToken);
            _sitterNegativeSteps.RestoreSitterProfileBySitterOrClientOrAnonimNegativeTest(_sitterId, _sitterToken);
            _sitterNegativeSteps.RestoreSitterProfileBySitterOrClientOrAnonimNegativeTest(_sitterId, _alienSitterToken);
            _sitterNegativeSteps.RestoreSitterProfileBySitterOrClientOrAnonimNegativeTest(_sitterId, _clientToken);
            _sitterNegativeSteps.RestoreSitterProfileBySitterOrClientOrAnonimNegativeTest(_sitterId, null);
        }

        [Test]
        public void AddingSitterProfileByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotAddingNewSitterProfile()
        {
            _sitterNegativeSteps.AddingSitterProfileBySitterOrAdminNegativeTest(_alienSitterModel, _clientToken);
            _sitterNegativeSteps.AddingSitterProfileBySitterOrAdminNegativeTest(_alienSitterModel, _adminToken);
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