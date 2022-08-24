using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
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
        private int _clientCommentId;
        private int _sitterCommentId;
        private ClientRegistrationRequestModel _clientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private AnimalRegistrationRequestModel _animalModel;
        private CommentAllInfoResponseModel _expectedClientComment;
        private CommentAllInfoResponseModel _expectedSitterComment;
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
            OrderWalkRegistrationRequestModel orderModel = new OrderWalkRegistrationRequestModel()
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
            _orderId = _clientSteps.RegisterOrderWalkTest(orderModel, _clientToken);
            OrderAllInfoResponseModel expectedOrder = _orderMappers.MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
                (_orderId, orderModel.WorkDate, _sitterModel.PriceCatalog[3].Price, _animals, orderModel, orderModel.Status);
            OrderAllInfoResponseModel actualOrder = _clientSteps.GetAllInfoOrderByIdTest(_orderId, _clientToken, expectedOrder);
            actualOrder.Status = 3;
            CommentRegistrationRequestModel clientCommentModel = new CommentRegistrationRequestModel()
            {
                Rating = 5,
                Text = "Собачка была под хорошим присмотром, и я не порвала себе сердце от беспокойства за неё.",
            };
            _clientCommentId = _clientSteps.RegisterCommentToOrderTest(_orderId, clientCommentModel, _clientToken);
            _expectedClientComment = _commentMappers.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (_clientCommentId, _orderId, clientCommentModel);
            CommentRegistrationRequestModel sitterCommentModel = new CommentRegistrationRequestModel()
            {
                Rating = 5,
                Text = "Хозяин вежливый, собака классная.",
            };
            _sitterCommentId = _sitterSteps.RegisterCommentToOrderTest(_orderId, sitterCommentModel, _sitterToken);
            _expectedSitterComment = _commentMappers.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (_sitterCommentId, _orderId, sitterCommentModel);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [Test]
        public void LeaveCommentOnServiceWalkByClient_WhenCommentModelIsCorrect_ShouldLeaveCommentOnServiceWalkByClient()
        {
            _adminSteps.FindAddedCommentByOrderIdTest(_orderId, _adminToken, _expectedClientComment);
        }

        [Test]
        public void LeaveCommentOnServiceWalkBySitter_WhenCommentModelIsCorrect_ShouldLeaveCommentOnServiceWalkBySitter()
        {
            _expectedSitterComment.IsClient = false;
            _adminSteps.FindAddedCommentByOrderIdTest(_orderId, _adminToken, _expectedSitterComment);
        }

        [Test]
        public void DeleteCommentOnServiceWalkByClient_WhenCommentIdIsCorrect_ShouldDeleteCommentOnServiceWalkByClient()
        {
            _clientSteps.DeleteCommentByIdTest(_clientCommentId, _clientToken);
            _expectedClientComment.IsDeleted = true;
            _adminSteps.FindDeletedCommentByOrderIdTest(_orderId, _adminToken, _expectedClientComment);
        }

        [Test]
        public void DeleteCommentOnServiceWalkBySitter_WhenCommentIdIsCorrect_ShouldDeleteCommentOnServiceWalkBySitter()
        {
            _sitterSteps.DeleteCommentByIdTest(_sitterCommentId, _sitterToken);
            _expectedSitterComment.IsClient = false;
            _expectedSitterComment.IsDeleted = true;
            _adminSteps.FindDeletedCommentByOrderIdTest(_orderId, _adminToken, _expectedSitterComment);
        }

        [Test]
        public void ViewCommentOnServiceWalkByAdmin_WhenCommentModelIsCorrect_ShouldViewCommentOnServiceWalkByAdmin()
        {
            _allComments.Add(_expectedClientComment);
            _allComments.Add(_expectedSitterComment);
            _adminSteps.ViewCommentByOrderIdTest(_orderId, _adminToken, _allComments);
        }

        [Test]
        public void DeleteCommentsOnServiceWalkByAdmin_WhenCommentSIdIsCorrect_ShouldDeleteCommentOnServiceWalkByAdmin()
        {
            _adminSteps.DeleteCommentByIdTest(_clientCommentId, _adminToken);
            _expectedClientComment.IsDeleted = true;
            _adminSteps.FindDeletedCommentByOrderIdTest(_orderId, _adminToken, _expectedClientComment);
            _adminSteps.DeleteCommentByIdTest(_sitterCommentId, _adminToken);
            _expectedSitterComment.IsClient = false;
            _expectedSitterComment.IsDeleted = true;
            _adminSteps.FindDeletedCommentByOrderIdTest(_orderId, _adminToken, _expectedSitterComment);
        }
    }
}