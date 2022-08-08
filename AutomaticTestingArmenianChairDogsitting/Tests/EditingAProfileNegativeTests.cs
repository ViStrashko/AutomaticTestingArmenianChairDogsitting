using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.NegativeTestSources.ClientNegativeTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
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
            };
            _alienSitterId = _sitterSteps.RegisterSitterTest(_alienSitterModel);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        //Clients
        [TestCaseSource(typeof(EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyIsEmpty_TestSource))]
        public void EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyIsEmpty_ShouldGetHttpStatusCodeUnprocessableEntity
            (ClientUpdateRequestModel clientUpdateModel)
        {
            _clientNegativeSteps.EditingClientsPropertyNegativeTest(_clientId, clientUpdateModel, _clientToken);
        }

        [TestCaseSource(typeof(EditingClientProfileNegativeTest_WhenUpdatedClientsPropertyPhoneAndEmailIncorrectFormat_TestSource))]
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
        public void EditingClientProfileNegativeTest_WhenUpdatedClientIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest()
        {
            var updatedClientId = _clientId + 100;
            ClientUpdateRequestModel clientUpdateModel = _clientMappers.MappClientRegistrationRequestModelToClientUpdateRequestModel(_clientModel);
            _clientNegativeSteps.EditingProfileByIncorrecUserIdNegativeTest(updatedClientId, clientUpdateModel, _clientToken);
        }

        [Test]
        public void DeleteClientProfileNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest()
        {
            var deletedClientId = _clientId + 100;
            _clientNegativeSteps.DeleteProfileByIncorrecUserIdNegativeTest(deletedClientId, _clientToken);
        }

        [Test]
        public void EditingSomeoneElsesClientProfileByClientNegativeTest_WhenClientIdIsCorrect_ShouldGetHttpStatusCodeForbidden()
        {
            ClientUpdateRequestModel _alienUpdatedClientModel = _clientMappers.MappClientRegistrationRequestModelToClientUpdateRequestModel(_alienClientModel);
            _clientNegativeSteps.EditingAlienProfileByCorrectUserIdNegativeTest(_alienClientId, _alienUpdatedClientModel, _clientToken);
        }

        [Test]
        public void EditingSomeoneElsesClientProfileByClientNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest()
        {
            var updatedClientId = _alienClientId + 100;
            ClientUpdateRequestModel _alienUpdatedClientModel = _clientMappers.MappClientRegistrationRequestModelToClientUpdateRequestModel(_alienClientModel);
            _clientNegativeSteps.EditingProfileByIncorrecUserIdNegativeTest(updatedClientId, _alienUpdatedClientModel, _clientToken);
        }

        [Test]
        public void DeleteSomeoneElsesClientProfileByClientNegativeTest_WhenClientIdIsCorrect_ShouldGetHttpStatusCodeForbidden()
        {
            _clientNegativeSteps.DeleteAlienProfileByCorrectUserIdNegativeTest(_alienClientId, _clientToken);
        }

        [Test]
        public void DeleteSomeoneElsesClientProfileByClientNegativeTest_WhenClientIdIsNotCorrect_ShouldGetHttpStatusCodeBadRequest()
        {
            var deletedClientId = _alienClientId + 100;
            _clientNegativeSteps.DeleteAlienProfileByCorrectUserIdNegativeTest(deletedClientId, _clientToken);
        }

        //Sitters
    }
}