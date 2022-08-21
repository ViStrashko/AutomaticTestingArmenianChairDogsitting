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
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private CommentMappers _commentMapper;
        private string _clientToken;
        private int _clientId;
        private int _sitterId;
        private int _animalId;
        private int _orderId;
        private ClientRegistrationRequestModel _clientModel;
        private SitterRegistrationRequestModel _sitterModel;
        private AnimalRegistrationRequestModel _animalModel;
        private OrderRegistrationRequestModel _orderModel;

        public LeaveACommentTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _commentMapper = new CommentMappers();
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
            _authorization.AuthorizeTest(authSitterModel);
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
            _orderModel = new OrderRegistrationRequestModel()
            {
                ClienId = _clientId,
                SitterId = _sitterId,
                WorkDate = DateTime.Now,
                Type = 1,
                Address = _clientModel.Address,
                AnimalIds = new List<int>()
                {
                    _animalId,
                }
            };
            _orderId = _clientSteps.RegisterOrderTest(_orderModel, _clientToken);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(LeaveCommentOnServiceByClient_WhenCommentModelIsCorrect_TestSource))]
        public void LeaveCommentOnServiceByClient_WhenCommentModelIsCorrect_ShouldLeaveCommentOnServiceByClient
            (CommentRegistrationRequestModel commentModel)
        {
            int commentId = _clientSteps.RegisterCommentToOrderTest(_orderId, commentModel, _clientToken);
            CommentAllInfoResponseModel expectedComment = _commentMapper.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (commentId, _orderId, commentModel);
            _clientSteps.FindAddedCommentByOrderIdTest(_orderId, _clientToken, expectedComment);
        }

        [TestCaseSource(typeof(DeleteCommentOnServiceByClient_WhenCommentIdIsCorrect_TestSource))]
        public void DeleteCommentOnServiceByClient_WhenCommentIdIsCorrect_ShouldDeleteCommentOnServiceByClient
            (CommentRegistrationRequestModel commentModel)
        {
            int commentId = _clientSteps.RegisterCommentToOrderTest(_orderId, commentModel, _clientToken);
            CommentAllInfoResponseModel expectedComment = _commentMapper.MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
                (commentId, _orderId, commentModel);
            _clientSteps.DeleteCommentByIdTest(commentId, _clientToken);
            _clientSteps.FindDeletedCommentByOrderIdTest(_orderId, _clientToken, expectedComment);
        }
    }
}