using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using System;
using System.Collections.Generic;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.ClientTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
{
    public class EditingSittersTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private SitterSteps _sitterSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private ClientMappers _clientMappers;
        private ClientRegistrationRequestModel _clientModel;


        public EditingSittersTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _sitterSteps = new SitterSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
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
            
        }
        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [Test]
        public void ChangingPasswordTest()
        {
            //зарегистрировать ситтера
            SitterRegistrationRequestModel model = new SitterRegistrationRequestModel()
            {
                Name = "Валера",
                LastName = "Пет",
                Email = "pet@gmail.com",
                Age = 20,
                Description = "Description",
                Experience = 10,
                Sex = 1,
                Phone = "+79514125547",
                Password = "12345678",
            };
            int id = _sitterSteps.RegisterSitter(model);

            //авторизация
            AuthRequestModel authRequest = new AuthRequestModel()
            {
                Email = model.Email,
                Password = model.Password
            };
            string token = _authorization.AuthorizeTest(authRequest);

            //изменение пароля 
            ChangSitterPasswordRequestModel changSitterPasswordRequestModel = new ChangSitterPasswordRequestModel()
            {
                Password = "829381923",
                OldPassword = model.Password
            };
            _sitterSteps.ChangSittersPassword(changSitterPasswordRequestModel, id, token);

            //проверить что нельзя зайти под старым паролем
            _authorization.AuthorizeTest_WhenLoginOrPasswordIsNotCorrect_ThenServerReturn422HttpCode(authRequest);

            //проверить что можно авторизоваться 
            authRequest.Password = changSitterPasswordRequestModel.Password;
            _authorization.AuthorizeTest(authRequest);
        }
    }
}
