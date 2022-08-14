using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.AnimalTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests.PositiveTests
{
    public class AddingAnimalToClientProfile
    {
        private Authorizations _authorization;
        private ClientSteps _clientSteps;
        private ClearingTables _clearingTables;
        private AuthMappers _authMapper;
        private AnimalMappers _animalMappers;
        private string _token;
        private int _clientId;
        private ClientRegistrationRequestModel _clientModel;

        public AddingAnimalToClientProfile()
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
        }

        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(AddingAnimalToClientProfile_WhenAnimalModelIsCorrect_TestSource))]
        public void RegisterAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldAddingAnimalToClientProfileAddGetAllInfoAnimalById
            (AnimalRegistrationRequestModel animalModel)
        {
            animalModel.ClientId = _clientId;
            int animalId  = _clientSteps.RegisterAnimalToClientProfileTest(animalModel, _token);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel
                (animalId, animalModel);
            _clientSteps.GetAllInfoAnimalByIdTest(animalId, _token, expectedAnimal);

            ClientsAnimalsResponseModel shortExpectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel
                (animalId, animalModel);
            _clientSteps.FindAddedAnimalInListTest(_clientId, _token, shortExpectedAnimal);

            _clientSteps.FindAddedAnimalInClientProfileTest(_clientId, _token, shortExpectedAnimal);
        }

        [TestCaseSource(typeof(AddingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOtherAndAnimalModelIsCorrect_TestSource))]
        public void RegisterAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldAddingAnimalToClientProfileWithPropertyBreedIsLarge
            (AnimalRegistrationRequestModel animalModel)
        {
            animalModel.ClientId = _clientId;
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(animalModel, _token);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel
                (animalId, animalModel);
            expectedAnimal.Breed = Options.propertyBreedLarge;
            _clientSteps.GetAllInfoAnimalByIdTest(animalId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(EditingAnimalToClientProfile_WhenAnimalModelIsCorrect_TestSourse))]
        public void EditingAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldEditingAnimalToClientProfile
            (AnimalRegistrationRequestModel animalModel, AnimalUpdateRequestModel animalUpdateModel)
        {
            animalModel.ClientId = _clientId;
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(animalModel, _token);

            _clientSteps.UpdateAnimalByIdTest(animalId, animalUpdateModel, _token);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalUpdateRequestModelToAnimalAllInfoResponseModel
                (animalId, animalUpdateModel);
            _clientSteps.GetAllInfoAnimalByIdTest(animalId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(EditingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOtherAndAnimalModelIsCorrect_TestSourse))]
        public void EditingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldEditingAnimalToClientProfileWithPropertyBreedIsLarge
            (AnimalRegistrationRequestModel animalModel, AnimalUpdateRequestModel animalUpdateModel)
        {
            animalModel.ClientId = _clientId;
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(animalModel, _token);

            _clientSteps.UpdateAnimalByIdTest(animalId, animalUpdateModel, _token);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalUpdateRequestModelToAnimalAllInfoResponseModel
                (animalId, animalUpdateModel);
            expectedAnimal.Breed = Options.propertyBreedLarge;
            _clientSteps.GetAllInfoAnimalByIdTest(animalId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(DeleteAnimalToClientProfile_WhenAnimalIdIsCorrect_TestSource))]
        public void DeleteAnimalToClientProfile_WhenAnimalIdIsCorrect_ShouldDeleteAnimalFromClientProfileAddGetAllInfoAnimalById
            (AnimalRegistrationRequestModel animalModel)
        {
            animalModel.ClientId = _clientId;
            int animalId = _clientSteps.RegisterAnimalToClientProfileTest(animalModel, _token);

            _clientSteps.DeleteAnimalByIdTest(animalId, _token);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel(animalId, animalModel);
            expectedAnimal.IsDeleted = true;
            _clientSteps.GetAllInfoAnimalByIdTest(animalId, _token, expectedAnimal);

            ClientsAnimalsResponseModel shortExpectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel(animalId, animalModel);
            _clientSteps.FindDeletedAnimalInListTest(_clientId, _token, shortExpectedAnimal);

            _clientSteps.FindDeletedAnimalInClientProfileTest(_clientId, _token, shortExpectedAnimal);
        }
    }
}
