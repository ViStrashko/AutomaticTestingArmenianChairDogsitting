using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.CommentTestSources;
using AutomaticTestingArmenianChairDogsitting.Models.Response;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
{
    public class LeaveACommentTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private AdminSteps _adminSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private CommentMappers _commentMappers;
        private OrderMappers _orderMappers;
        private AnimalMappers _animalMappers;
        private string _clientToken;
        private string _sitterToken;
        private string _adminToken;
        private int _clientId;
        private int _sitterId;
        private int _animalId;
        private int _orderId;
        private ClientRegistrationRequestModel _clientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private AnimalRegistrationRequestModel _animalModel;
        private OrderWalkRegistrationRequestModel _orderModel;
        private List<ClientsAnimalsResponseModel> _animals;
        private List<CommentAllInfoResponseModel> _allComments;

        public LeaveACommentTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _adminSteps = new AdminSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _commentMappers = new CommentMappers();
            _orderMappers = new OrderMappers();
            _animalMappers = new AnimalMappers();
            _animals = new List<ClientsAnimalsResponseModel>();
            _allComments = new List<CommentAllInfoResponseModel>();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _clearingTables.ClearAllDB();
        }

        [SetUp]
        public void SetUp()
        {
            var date = DateTime.Now;
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
                    new PriceCatalogRequestModel() { Service = 1, Price = 5000 },
                    new PriceCatalogRequestModel() { Service = 2, Price = 4000 },
                    new PriceCatalogRequestModel() { Service = 3, Price = 800 },
                    new PriceCatalogRequestModel() { Service = 4, Price = 500 }
                }
            };
            _sitterId = _sitterSteps.RegisterSitterTest(_sitterModel);
            AuthRequestModel authSitterModel = _authMapper.MappSitterRegistrationRequestModelToAuthRequestModel(_sitterModel);
            _sitterToken = _authorization.AuthorizeTest(authSitterModel);
            _animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _clientId,
            };
            _animalId = _clientSteps.RegisterAnimalToClientProfileTest(_animalModel, _clientToken);
            _animals.Add(_animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(_animalId, _animalModel));
            _orderModel = new OrderWalkRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = date,
                Address = _clientModel.Address,
                District = 2,
                Type = _sitterModel.PriceCatalog[3].Service,
                IsTrial = false,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            _orderId = _clientSteps.RegisterOrderWalkTest(_orderModel, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (_orderId, date, _sitterModel.PriceCatalog[3].Price, _animals, _orderModel, _orderModel.Status);
            OrderAllInfoResponseModel actualOrder = _clientSteps.GetAllInfoOrderByIdTest(_orderId, _clientToken, expectedOrder);
            actualOrder.Status = 3;
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(LeaveCommentOnServiceByClient_WhenCommentModelIsCorrect_TestSource))]
        public void LeaveCommentOnServiceWalkByClient_WhenCommentModelIsCorrect_ShouldLeaveCommentOnServiceWalkByClient
            (CommentRegistrationRequestModel commentModel)
        {
            var commentId = _clientSteps.RegisterCommentToOrderTest(_orderId, commentModel, _clientToken);
            CommentAllInfoResponseModel expectedComment = _commentMappers.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (commentId, _orderId, commentModel);
            _adminSteps.FindAddedCommentByOrderIdTest(_orderId, _adminToken, expectedComment);
        }

        [TestCaseSource(typeof(LeaveCommentOnServiceByClient_WhenCommentModelIsCorrect_TestSource))]
        public void DeleteCommentOnServiceWalkByClient_WhenCommentIdIsCorrect_ShouldDeleteCommentOnServiceWalkByClient
            (CommentRegistrationRequestModel commentModel)
        {
            var commentId = _clientSteps.RegisterCommentToOrderTest(_orderId, commentModel, _clientToken);
            CommentAllInfoResponseModel expectedComment = _commentMappers.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (commentId, _orderId, commentModel);
            _clientSteps.DeleteCommentByIdTest(commentId, _clientToken);
            expectedComment.IsDeleted = true;
            _adminSteps.FindDeletedCommentByOrderIdTest(_orderId, _adminToken, expectedComment);
        }

        [TestCaseSource(typeof(LeaveCommentOnServiceBySitter_WhenCommentModelIsCorrect_TestSource))]
        public void LeaveCommentOnServiceWalkBySitter_WhenCommentModelIsCorrect_ShouldLeaveCommentOnServiceWalkBySitter
            (CommentRegistrationRequestModel commentModel)
        {
            var commentId = _sitterSteps.RegisterCommentToOrderTest(_orderId, commentModel, _sitterToken);
            CommentAllInfoResponseModel expectedComment = _commentMappers.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (commentId, _orderId, commentModel);
            expectedComment.IsClient = false;
            _adminSteps.FindAddedCommentByOrderIdTest(_orderId, _adminToken, expectedComment);
        }

        [TestCaseSource(typeof(LeaveCommentOnServiceBySitter_WhenCommentModelIsCorrect_TestSource))]
        public void DeleteCommentOnServiceBySitter_WhenCommentIdIsCorrect_ShouldDeleteCommentOnServiceBySitter
            (CommentRegistrationRequestModel commentModel)
        {
            var commentId = _sitterSteps.RegisterCommentToOrderTest(_orderId, commentModel, _sitterToken);
            CommentAllInfoResponseModel expectedComment = _commentMappers.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (commentId, _orderId, commentModel);
            _clientSteps.DeleteCommentByIdTest(commentId, _sitterToken);
            expectedComment.IsClient = false;
            expectedComment.IsDeleted = true;
            _adminSteps.FindDeletedCommentByOrderIdTest(_orderId, _adminToken, expectedComment);
        }

        [TestCaseSource(typeof(ViewCommentOnServiceWalkByAdmin_WhenCommentModelIsCorrect_TestSource))]
        public void ViewCommentOnServiceWalkByAdmin_WhenCommentModelIsCorrect_ShouldViewCommentOnServiceWalkByAdmin
            (CommentRegistrationRequestModel clientCommentModel, CommentRegistrationRequestModel sitterCommentModel)
        {
            var clientCommentId = _clientSteps.RegisterCommentToOrderTest(_orderId, clientCommentModel, _clientToken);
            var sitterCommentId = _sitterSteps.RegisterCommentToOrderTest(_orderId, sitterCommentModel, _sitterToken);
            CommentAllInfoResponseModel expectedClientComment = _commentMappers.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (clientCommentId, _orderId, clientCommentModel);
            CommentAllInfoResponseModel expectedSitterComment = _commentMappers.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (sitterCommentId, _orderId, sitterCommentModel);
            _allComments.Add(expectedClientComment);
            _allComments.Add(expectedSitterComment);
            _adminSteps.ViewCommentByOrderIdTest(_orderId, _adminToken, _allComments);
        }
    }
}