using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ClientTestSources;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.SitterTestSources;

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
        private SitterMappers _sitterMappers;
        private string _clientToken;
        private string _sitterToken;
        private int _clientId;
        private int _sitterId;
        private ClientRegistrationRequestModel _clientModel;
        private SitterRegistrationRequestModel _sitterModel;

        public EditingAProfileTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
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
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(EditingClientProfile_WhenClientModelIsCorrect_TestSource))]
        public void EditingClientProfile_WhenClientModelIsCorrect_ShouldEditingClientProfile(ClientUpdateRequestModel clientUpdateModel)
        {
            _clientSteps.UpdateClientByIdTest(_clientId, clientUpdateModel, _clientToken);
            var date = DateTime.Now.Date;

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientUpdateRequestModelToClientAllInfoResponseModel(_clientId, date, clientUpdateModel);
            _clientSteps.GetAllInfoClientByIdTest(_clientId, _clientToken, expectedClient);
        }

        [Test]
        public void DeleteClientProfile_WhenClientIdIsCorrect_ShouldDeletingClientProfile()
        {
            _clientSteps.DeleteClientByIdTest(_clientId, _clientToken);
            var date = DateTime.Now.Date;

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientRegistrationRequestModelToClientAllInfoResponseModel(_clientId, date, _clientModel);
            expectedClient.IsDeleted = true;
            _clientSteps.GetAllInfoClientByIdTest(_clientId, _clientToken, expectedClient);
        }

        [TestCaseSource(typeof(EditingSitterProfile_WhenSitterModelIsCorrect_TestSource))]
        public void EditingSitterProfile_WhenSitterModelIsCorrect_ShouldEditingSitterProfile(SitterUpdateRequestModel sitterUpdateModel)
        {
            _sitterSteps.UpdateSitterByIdTest(_sitterId, sitterUpdateModel, _sitterToken);

            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterUpdateRequestModelToSitterAllInfoResponseModel(_sitterId, sitterUpdateModel);
            expectedSitter.Email = _sitterModel.Email;
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _sitterToken, expectedSitter);
        }

        [Test]
        public void DeleteSitterProfile_WhenSitterIdIsCorrect_ShouldDeletingSitterProfile()
        {
            _sitterSteps.DeleteSitterByIdTest(_sitterId, _sitterToken);

            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(_sitterId, _sitterModel);
            expectedSitter.IsDeleted = true;
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _sitterToken, expectedSitter);
        }

        [TestCaseSource(typeof(ChangingPasswordTest_WhenChangeSitterPasswordRequestModelIsCorrect_TestSource))]
        public void ChangingPasswordTest_WhenChangeSitterPasswordRequestModelIsCorrect_ShouldChangingPasswordByProfile
            (ChangePasswordRequestModel changePasswordModel)
        {
            changePasswordModel.OldPassword = _sitterModel.Password;
            _sitterSteps.ChangeSittersPassword(_sitterId, changePasswordModel, _sitterToken);

            AuthRequestModel authRequest = new AuthRequestModel();
            authRequest.Email = _sitterModel.Email;
            authRequest.Password = _sitterModel.Password;
            _authorization.AuthorizeTest_WhenLoginOrPasswordIsNotCorrect_ThenServerReturn422HttpCode(authRequest);

            authRequest.Password = changePasswordModel.Password;
            _authorization.AuthorizeTest(authRequest);
        }
    }
}
