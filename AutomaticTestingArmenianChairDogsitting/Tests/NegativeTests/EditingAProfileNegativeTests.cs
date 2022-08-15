using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.AnimalNegativeTestSources;
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
        private string _adminToken;
        private string _clientToken;
        private string _sitterToken;
        private string _alienClientToken;
        private string _alienSitterToken;
        private int _clientId;
        private int _alienClientId;        
        private int _sitterId;
        private int _alienSitterId;
        private ClientRegistrationRequestModel _clientModel;
        private ClientRegistrationRequestModel _alienClientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private SitterRegistrationRequestModel _alienSitterModel;

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
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.ClearAllDB();
            _adminToken = _authorization.AuthorizeTest(new AuthRequestModel() { Email = Options.adminEmail, Password = Options.adminPassword });
        }

        [SetUp]
        public void SetUp()
        {
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
                Experience = 10,
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
                Experience = 10,
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
            (AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.EditingAnimalWhenAnimalsPropertyEmptyAndNotCorrectNegativeTest(model, _clientToken);
        }

        [TestCaseSource(typeof(EditingAnimalToClientProfileNegativeTest_WhenAnimalIdIsNotCorrect_TestSource))]
        public void EditingAnimalToClientProfileNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest
            (int id, AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.EditingAnimalWhenAnimalIdIsNotCorrectNegativeTest(id, model, _clientToken);
        }

        [TestCaseSource(typeof(DeleteAnimalToClientProfileNegativeTest_WhenAnimalIdIsNotCorrect_TestSource))]
        public void DeleteAnimalToClientProfileNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest
            (int id, AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.DeleteAnimalWhenAnimalIdIsNotCorrectNegativeTest(id, model, _clientToken);
        }

        [TestCaseSource(typeof(GetAnimalByAnimalIdNegativeTest_WhenAnimalIdIsNotCorrect_TestSource))]
        public void GetAnimalByAnimalIdNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeNotFound
            (int id, AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.GetAnimalWhenAnimalIdIsNotCorrectNegativeTest(id, model, _clientToken);
        }

        [TestCaseSource(typeof(GetAnimalsByClientIdNegativeTest_WhenClientIdIsNotCorrect_TestSource))]
        public void GetAnimalsByClientIdNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeNotFound
            (int id, AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.GetAnimalsWhenClientIdIsNotCorrectNegativeTest(id, model, _clientToken);
        }


        //Sitters


        //All roles
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
            _clientNegativeSteps.AddingClientProfileByClientOrAdminNegativeTest(_clientToken, _alienClientModel);
            _clientNegativeSteps.AddingClientProfileByClientOrAdminNegativeTest(_adminToken, _alienClientModel);
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

        [TestCaseSource(typeof(RegisterAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_TestSource))]
        public void RegisterAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotRegisterAnimal
            (AnimalRegistrationRequestModel model)
        {
            _clientNegativeSteps.RegisterAnimalBySitterOrAdminNegativeTest(model, _adminToken);
            _clientNegativeSteps.RegisterAnimalBySitterOrAdminNegativeTest(model, _sitterToken);
            _clientNegativeSteps.RegisterAnimalByAnonimNegativeTest(model, null);
        }

        [TestCaseSource(typeof(RegisterAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_TestSource))]
        public void EditingAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotEditingAnimal
            (AnimalRegistrationRequestModel model)
        {
            _clientNegativeSteps.EditingAnimalBySitterOrAdminNegativeTest(model, _adminToken);
            _clientNegativeSteps.EditingAnimalBySitterOrAdminNegativeTest(model, _sitterToken);
            _clientNegativeSteps.EditingAnimalByAnonimNegativeTest(model, null);
        }

        [TestCaseSource(typeof(RegisterAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_TestSource))]
        public void DeleteAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotDeleteAnimal
            (AnimalRegistrationRequestModel model)
        {
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminNegativeTest(model, _adminToken);
            _clientNegativeSteps.DeleteAnimalBySitterOrAdminNegativeTest(model, _sitterToken);
            _clientNegativeSteps.DeleteAnimalByAnonimNegativeTest(model, null);
        }

        [TestCaseSource(typeof(RegisterAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_TestSource))]
        public void GetAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetAnimal
            (AnimalRegistrationRequestModel model)
        {
            _clientNegativeSteps.GetAnimalBySitterOrAdminNegativeTest(model, _adminToken);
            _clientNegativeSteps.GetAnimalBySitterOrAdminNegativeTest(model, _sitterToken);
            _clientNegativeSteps.GetAnimalByAnonimNegativeTest(model, null);
        }

        [TestCaseSource(typeof(RegisterAnimalByIncorrectRoleNegativeTest_ByAllIncorrectRoles_TestSource))]
        public void GetAnimalsByIncorrectRoleNegativeTest_ByAllIncorrectRoles_ShouldNotGetAnimals
            (AnimalRegistrationRequestModel model)
        {
            _clientNegativeSteps.GetAnimalsBySitterNegativeTest(_sitterId, model, _sitterToken);
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
            _sitterNegativeSteps.RestoreSitterProfileWithNotCorrectIdTest(id, _adminToken);
        }
    }
}