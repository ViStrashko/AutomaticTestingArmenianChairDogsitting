using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ViewTestSources;
using System;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
{
    public class AdminsTests
    {
        private Authorizations _authorization;
        private AdminSteps _adminSteps;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private SitterMappers _sitterMappers;
        private ClientMappers _clientMappers;
        private string _clientToken;
        private string _sitterToken;
        private int _clientId;
        private int _sitterId;
        private string _adminToken;
        private ClientRegistrationRequestModel _clientModel;
        private SitterRegistrationRequestModel _sitterModel;        

        public AdminsTests()
        {
            _authorization = new Authorizations();
            _adminSteps = new AdminSteps();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _sitterMappers = new SitterMappers();
            _clientMappers = new ClientMappers();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.ClearAllDB();
        }

        [SetUp]
        public void SetUp()
        {
            _adminToken = _authorization.AuthorizeTest(new AuthRequestModel { Email = Options.adminEmail, Password = Options.adminPassword });

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

        [Test]
        public void RestoringClientProfileByClientIdTest_WhenClientIdIsCorrect_ShouldRestoringClientProfile()
        {
            var date = DateTime.Now.Date;
            ClientsGetAllResponseModel expectedClient = _clientMappers.MappClientRegistrationRequestModelToClientsGetAllResponseModel
                (_clientId, date, _clientModel);
            _clientSteps.DeleteClientByIdTest(_clientId, _clientToken);

            _adminSteps.FindDeletedClientProfileInListTest(_adminToken, expectedClient);

            _adminSteps.RestoringClientProfileByClientIdTest(_clientId, _adminToken);

            _adminSteps.FindAddedClientProfileInListTest(_adminToken, expectedClient);
        }

        [Test]
        public void RestoringSitterProfileBySitterIdTest_WhenSitterIdIsCorrect_ShouldRestoringSitterProfile()
        {
            SittersGetAllResponseModel expectedSitter = _sitterMappers.MappSitterRegistrationModelToSittersGetAllResponseModel
                (_sitterId, _sitterModel);
            _sitterSteps.DeleteSitterByIdTest(_sitterId, _sitterToken);

            _adminSteps.FindDeletedSitterProfileInListTest(_adminToken, expectedSitter);

            _adminSteps.RestoreSittersProfileBySitterIdTest(_sitterId, _adminToken);

            _adminSteps.FindAddedSitterProfileInListTest(_adminToken, expectedSitter);
        }

        [TestCaseSource(typeof(GetAllSittersByAnyRoleTestSource))]
        public void RestoreSittersProfileTest_ByAdmin_ShouldRestoreProfile(List<SitterRegistrationRequestModel> sitters)
        {
            SitterAllInfoResponseModel expectedSitter =
                _sitterMappers.MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(_sitterId, _sitterModel);
            SitterAllInfoResponseModel expectedDeletedSitter = new SitterAllInfoResponseModel()
            {
                Age = expectedSitter.Age,
                Description = expectedSitter.Description,
                Email = expectedSitter.Email,
                Experience = expectedSitter.Experience,
                Phone = expectedSitter.Phone,
                PriceCatalog = expectedSitter.PriceCatalog,
                Id = expectedSitter.Id,
                Name = expectedSitter.Name,
                LastName = expectedSitter.LastName,
                Sex = expectedSitter.Sex,
                IsDeleted = true
            };
            SittersGetAllResponseModel expectedSitterInAllSitters =
                _sitterMappers.MappSitterRegistrationModelToSittersGetAllResponseModel(_sitterId, _sitterModel);
            List<SittersGetAllResponseModel> expectedAllSitters = new List<SittersGetAllResponseModel>();
            foreach (var sitter in sitters)
            {
                expectedAllSitters.Add(_sitterMappers.MappSitterRegistrationModelToSittersGetAllResponseModel(
                        _sitterSteps.RegisterSitterTest(sitter), sitter));
            }
            _sitterSteps.DeleteSitterByIdTest(_sitterId, _sitterToken);
            _sitterSteps.CheckThatAllSittersDoesNotContainsDeletedSitterTest(_clientToken, expectedSitterInAllSitters);
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _adminToken, expectedDeletedSitter);
            _adminSteps.RestoreSittersProfileBySitterIdTest(_sitterId, _adminToken);
            _sitterSteps.GetAllInfoAllSittersTest(_adminToken, expectedAllSitters);
            _sitterSteps.GetAllInfoSitterByIdTest(_sitterId, _adminToken, expectedSitter);
        }
    }
}
