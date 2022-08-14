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
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private ClientMappers _clientMappers;
        private SitterMappers _sitterMappers;
        private string _clientToken;
        private string _sitterToken;
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
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _clientMappers = new ClientMappers();
            _sitterMappers = new SitterMappers();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.ClearAllDB();
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

        [Test]
        public void EditingClientProfileByClientNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeForbidden()
        {
            ClientUpdateRequestModel clientUpdateModel = _clientMappers.MappClientRegistrationRequestModelToClientUpdateRequestModel(_clientModel);
            _clientNegativeSteps.EditingClientProfileByClientIdNegativeTest(_alienClientId, clientUpdateModel, _clientToken);
        }

        [Test]
        public void DeleteClientProfileByClientNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeForbidden()
        {
            _clientNegativeSteps.DeleteClientProfileByClientIdNegativeTest(_alienClientId, _clientToken);
        }

        [Test]
        public void AddingNewClientProfileNegativeTest_WhenAlreadyHaveClientProfile_ShouldGetHttpStatusCodeForbidden()
        {
            _clientNegativeSteps.AddingNewClientProfileWhenAlreadyHaveClientProfileNegativeTest(_clientToken, _alienClientModel);
        }

        [Test]
        public void GetClientProfilesNegativeTest_WhenAlreadyHaveClientProfile_ShouldGetHttpStatusCodeNotFound()
        {
            _clientNegativeSteps.GetClientProfilesNegativeTest(_clientToken);
        }

        [Test]
        public void GetClientProfileByClientIdNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeNotFound()
        {
            _clientNegativeSteps.GetClientProfileByClientIdNegativeTest(_alienClientId, _clientToken);
        }

        [Test]
        public void RestoringClientProfileByClientIdNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeForbidden()
        {
            _clientNegativeSteps.RestoringClientProfileByClientByIdNegativeTest(_alienClientId, _clientToken);
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
            model.ClientId = _clientId + 100;
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
            (AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.EditingAnimalWhenAnimalIdIsNotCorrectNegativeTest(model, _clientToken);
        }

        [TestCaseSource(typeof(DeleteAnimalToClientProfileNegativeTest_WhenAnimalIdIsNotCorrect_TestSource))]
        public void DeleteAnimalToClientProfileNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest
            (AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.DeleteAnimalWhenAnimalIdIsNotCorrectNegativeTest(model, _clientToken);
        }

        [TestCaseSource(typeof(GetAnimalByAnimalIdNegativeTest_WhenAnimalIdIsNotCorrect_TestSource))]
        public void GetAnimalByAnimalIdNegativeTest_WhenAnimalIdIsNotCorrect_ShouldGetHttpStatusCodeNotFound
            (AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            _clientNegativeSteps.GetAnimalWhenAnimalIdIsNotCorrectNegativeTest(model, _clientToken);
        }

        [TestCaseSource(typeof(GetAnimalsByClientIdNegativeTest_WhenClientIdIsNotCorrect_TestSource))]
        public void GetAnimalsByClientIdNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeNotFound
            (AnimalRegistrationRequestModel model)
        {
            model.ClientId = _clientId;
            var _newClientId = _clientId + 100;
            _clientNegativeSteps.GetAnimalsWhenClientIdIsNotCorrectNegativeTest(_newClientId, model, _clientToken);
        }


        //Sitters
    }
}