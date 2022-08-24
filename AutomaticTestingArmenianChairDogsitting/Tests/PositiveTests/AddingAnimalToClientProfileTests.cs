using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.AnimalTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
{
    public class AddingAnimalToClientProfileTests
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private AnimalMappers _animalMappers;
        private string _token;
        private int _clientId;
        private int _animalId;
        private ClientRegistrationRequestModel _clientModel;
        private AnimalRegistrationRequestModel _animalModel;

        public AddingAnimalToClientProfileTests()
        {
            _authorization = new Authorizations();
            _clientSteps = new ClientSteps();
            _clearingTables = new ClearingTables();
            _authMapper = new AuthMappers();
            _animalMappers = new AnimalMappers();
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
            AuthRequestModel authModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _token = _authorization.AuthorizeTest(authModel);
            _animalModel = new AnimalRegistrationRequestModel()
            {
                Name = "Шарик",
                Age = 1,
                RecommendationsForCare = "Играть осторожно",
                Breed = "Доберман",
                Size = 5,
                ClientId = _clientId,
            };
            _animalId = _clientSteps.RegisterAnimalToClientProfileTest(_animalModel, _token);
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [Test]
        public void RegisterAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldAddingAnimalToClientProfileAddGetAllInfoAnimalById()
        {
            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel(_animalId, _animalModel);
            _clientSteps.GetAllInfoAnimalByIdTest(_animalId, _token, expectedAnimal);
            ClientsAnimalsResponseModel shortExpectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel
                (_animalId, _animalModel);
            _clientSteps.FindAddedAnimalInListTest(_clientId, _token, shortExpectedAnimal);
            _clientSteps.FindAddedAnimalInClientProfileTest(_clientId, _token, shortExpectedAnimal);
        }

        [Test]
        public void RegisterAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldAddingAnimalToClientProfileWithPropertyBreedIsLarge()
        {
            _animalModel.Breed = Options.propertyBreedOther;
            var animalId = _clientSteps.RegisterAnimalToClientProfileTest(_animalModel, _token);
            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel
                (animalId, _animalModel);
            expectedAnimal.Breed = Options.propertyBreedLarge;
            _clientSteps.GetAllInfoAnimalByIdTest(animalId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(EditingAnimalToClientProfile_WhenAnimalModelIsCorrect_TestSourse))]
        public void EditingAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldEditingAnimalToClientProfile
            (AnimalUpdateRequestModel animalUpdateModel)
        {
            _clientSteps.UpdateAnimalByIdTest(_animalId, animalUpdateModel, _token);
            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalUpdateRequestModelToAnimalAllInfoResponseModel
                (_animalId, animalUpdateModel);
            _clientSteps.GetAllInfoAnimalByIdTest(_animalId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(EditingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOtherAndAnimalModelIsCorrect_TestSourse))]
        public void EditingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldEditingAnimalToClientProfileWithPropertyBreedIsLarge
            (AnimalUpdateRequestModel animalUpdateModel)
        {
            _clientSteps.UpdateAnimalByIdTest(_animalId, animalUpdateModel, _token);
            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalUpdateRequestModelToAnimalAllInfoResponseModel
                (_animalId, animalUpdateModel);
            expectedAnimal.Breed = Options.propertyBreedLarge;
            _clientSteps.GetAllInfoAnimalByIdTest(_animalId, _token, expectedAnimal);
        }

        [Test]
        public void DeleteAnimalToClientProfile_WhenAnimalIdIsCorrect_ShouldDeleteAnimalFromClientProfileAddGetAllInfoAnimalById
            (AnimalRegistrationRequestModel animalModel)
        {
            _clientSteps.DeleteAnimalByIdTest(_animalId, _token);
            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel(_animalId, animalModel);
            expectedAnimal.IsDeleted = true;
            _clientSteps.GetAllInfoAnimalByIdTest(_animalId, _token, expectedAnimal);
            ClientsAnimalsResponseModel shortExpectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(_animalId, animalModel);
            _clientSteps.FindDeletedAnimalInListTest(_clientId, _token, shortExpectedAnimal);
            _clientSteps.FindDeletedAnimalInClientProfileTest(_clientId, _token, shortExpectedAnimal);
        }

        [Test]
        public void RestoreAnimalToClientProfile_WhenAnimalIdIsCorrect_ShouldRestoreAnimalFromClientProfileAddGetAllInfoAnimalById
            (AnimalRegistrationRequestModel animalModel)
        {
            _clientSteps.DeleteAnimalByIdTest(_animalId, _token);
            ClientsAnimalsResponseModel shortExpectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(_animalId, animalModel);
            _clientSteps.FindDeletedAnimalInClientProfileTest(_clientId, _token, shortExpectedAnimal);
            _clientSteps.RestoreAnimalByIdTest(_animalId, _token);
            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel(_animalId, animalModel);
            _clientSteps.GetAllInfoAnimalByIdTest(_animalId, _token, expectedAnimal);
        }
    }
}
