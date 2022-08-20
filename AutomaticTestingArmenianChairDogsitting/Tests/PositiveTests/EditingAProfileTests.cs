using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ClientTestSources;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.SitterTestSources;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
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
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(EditingClientProfileTest_WhenClientModelIsCorrect_TestSource))]
        public void EditingClientProfileTest_WhenClientModelIsCorrect_ShouldEditingClientProfile(ClientUpdateRequestModel clientUpdateModel)
        {
            _clientSteps.UpdateClientTest(clientUpdateModel, _clientToken);
            var date = DateTime.Now;

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientUpdateRequestModelToClientAllInfoResponseModel
                (_clientId, date, _clientModel.Email, clientUpdateModel);
            _clientSteps.GetAllInfoClientByIdTest(_clientId, _clientToken, expectedClient);
        }

        [Test]
        public void DeleteClientProfileTest_WhenClientIdIsCorrect_ShouldDeletingClientProfile()
        {
            _clientSteps.DeleteClientTest(_clientToken);
            var date = DateTime.Now;

            ClientAllInfoResponseModel expectedClient = _clientMappers.MappClientRegistrationRequestModelToClientAllInfoResponseModel
                (_clientId, date, _clientModel);
            expectedClient.IsDeleted = true;
            _clientSteps.GetAllInfoClientByIdTest(_clientId, _clientToken, expectedClient);
        }

        [TestCaseSource(typeof(ChangingClientPasswordTest_WhenChangeClientPasswordRequestModelIsCorrect_TestSource))]
        public void ChangingClientPasswordTest_WhenChangeClientPasswordRequestModelIsCorrect_ShouldChangingClientPasswordByProfile
           (ChangePasswordRequestModel changePasswordModel)
        {
            changePasswordModel.OldPassword = _clientModel.Password;
            _clientSteps.ChangeClientsPasswordTest(changePasswordModel, _sitterToken);

            AuthRequestModel authRequest = new AuthRequestModel();
            authRequest.Email = _clientModel.Email;
            authRequest.Password = _clientModel.Password;
            _authorization.AuthorizeWhenAuthenticationFailedNegativeTest(authRequest);

            authRequest.Password = changePasswordModel.Password;
            _authorization.AuthorizeTest(authRequest);
        }

        [TestCaseSource(typeof(EditingSitterProfileTest_WhenSitterModelIsCorrect_TestSource))]
        public void EditingSitterProfileTest_WhenSitterModelIsCorrect_ShouldEditingSitterProfile(SitterUpdateRequestModel sitterUpdateModel)
        {
            _sitterSteps.UpdateSitterTest(sitterUpdateModel, _sitterToken);

            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterUpdateRequestModelToSitterAllInfoResponseModel
                (_sitterId, _sitterModel.Email, _sitterModel.PriceCatalog, sitterUpdateModel);
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _sitterToken, expectedSitter);
        }

        [Test]
        public void DeleteSitterProfileTest_WhenSitterIdIsCorrect_ShouldDeletingSitterProfile()
        {
            _sitterSteps.DeleteSitterTest(_sitterToken);

            SitterAllInfoResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel
                (_sitterId, _sitterModel);
            expectedSitter.IsDeleted = true;
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _sitterToken, expectedSitter);
        }

        [TestCaseSource(typeof(ChangingSitterPasswordTest_WhenChangeSitterPasswordRequestModelIsCorrect_TestSource))]
        public void ChangingSitterPasswordTest_WhenChangeSitterPasswordRequestModelIsCorrect_ShouldChangingSitterPasswordByProfile
            (ChangePasswordRequestModel changePasswordModel)
        {
            changePasswordModel.OldPassword = _sitterModel.Password;
            _sitterSteps.ChangeSittersPasswordTest(changePasswordModel, _sitterToken);

            AuthRequestModel authRequest = new AuthRequestModel();
            authRequest.Email = _sitterModel.Email;
            authRequest.Password = _sitterModel.Password;
            _authorization.AuthorizeWhenAuthenticationFailedNegativeTest(authRequest);

            authRequest.Password = changePasswordModel.Password;
            _authorization.AuthorizeTest(authRequest);
        }

        [TestCaseSource(typeof(ChangingSittersPriceCatalogTest_WhenModelIsCorrect_TestSource))]
        public void ChangingSittersPriceCatalogTest_WhenModelIsCorrect_ShouldChangePrices(PriceCatalogUpdateModel newPrices)
        {
            _sitterSteps.UpdatePriceCatalogTest(newPrices, _sitterToken);
            SitterAllInfoResponseModel expectedSitter = 
                _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(_sitterId, _sitterModel);
            expectedSitter.PriceCatalog = _sitterMappers.MappPriceCatalogRequestModelToPriceCatalogResponseModel(newPrices.PriceCatalog);

            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _sitterToken, expectedSitter);
        }
    }
}
