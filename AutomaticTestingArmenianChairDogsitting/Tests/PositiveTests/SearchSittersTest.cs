using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using System.Collections.Generic;
using System;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.SearchSittersTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
{
    public class SearchSittersTest
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private SitterMappers _sitterMappers;
        private AnimalMappers _animalMappers;
        private OrderMappers _orderMappers;
        private AuthMappers _authMapper;
        private string _clientToken;
        private string _alienClientToken;
        private int _alienClientId;
        private int _animalId;
        ClientRegistrationRequestModel _clientModel;
        ClientRegistrationRequestModel _alienClientModel;
        AnimalRegistrationRequestModel _animalModel;
        private List<ClientsAnimalsResponseModel> _animals;

        public SearchSittersTest()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _animalMappers = new AnimalMappers();
            _orderMappers = new OrderMappers();
            _clearingTables = new ClearingTables();
            _sitterMappers = new SitterMappers();
            _authMapper = new AuthMappers();
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
            _clientSteps.RegisterClientTest(_clientModel);
            AuthRequestModel authClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _clientToken = _authorization.AuthorizeTest(authClientModel);
            _alienClientModel = new ClientRegistrationRequestModel()
            {
                Name = "Николай",
                LastName = "Петров",
                Email = "petrov@gmail.com",
                Phone = "89514425547",
                Address = "ул. Пражская, дом. 15",
                Password = "18885678",
                Promocode = ""
            };
            _alienClientId = _clientSteps.RegisterClientTest(_alienClientModel);
            AuthRequestModel authAlienClientModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_alienClientModel);
            _alienClientToken = _authorization.AuthorizeTest(authAlienClientModel);
            _animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _alienClientId,
            };
            _animalId = _clientSteps.RegisterAnimalToClientProfileTest(_animalModel, _alienClientToken);
            _animals.Add(_animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(_animalId, _animalModel));
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(SearchSittersTest_WhenUserModelIsCorrectAndSearchRequestModelIsCorrect_TestSource))]
        public void SearchSittersTest_WhenUserModelIsCorrectAndSearchRequestModelIsCorrect_ShouldSearchSitters
            (List<SitterRegistrationRequestModel> sitters, CommentRegistrationRequestModel commentModel)
        {
            var date = DateTime.Now;
            List<SittersGetAllResponseModel> sittersList = new List<SittersGetAllResponseModel>();
            foreach (var sitter in sitters)
            {
                int sitterId = _sitterSteps.RegisterSitterTest(sitter);
                sittersList.Add(_sitterMappers.MappSitterRegistrationModelToSittersGetAllResponseModel(sitterId, sitter));
            }
            OrderWalkRegistrationRequestModel orderModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _alienClientId,
                SitterId = _sitterSteps.RegisterSitterTest(sitters[0]),
                WorkDate = date,
                Address = _alienClientModel.Address,
                District = 2,
                Type = sitters[0].PriceCatalog[3].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            var orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _alienClientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (orderId, orderModel.WorkDate, sitters[0].PriceCatalog[3].Price, _animals, orderModel, orderModel.Status);
            OrderAllInfoResponseModel actualOrder = _clientSteps.GetAllInfoOrderByIdTest(orderId, _alienClientToken, expectedOrder);
            actualOrder.Status = 3;
            _clientSteps.RegisterCommentToOrderTest(orderId, commentModel, _alienClientToken);
            SearchRequestModel searchModel = new SearchRequestModel()
            {
                PriceMinimum = 300,
                PriceMaximum = 900,
                MinRating = 1,
                District = null,
                ServiceType = 4,
                IsSitterHasComments = true,
            };
            List<SittersGetAllResponseModel> expectedSitters = new List<SittersGetAllResponseModel>();
            expectedSitters.Add(sittersList[0]);
            _clientSteps.SearchSittersTest(searchModel, _clientToken, expectedSitters);
        }
    }
}
