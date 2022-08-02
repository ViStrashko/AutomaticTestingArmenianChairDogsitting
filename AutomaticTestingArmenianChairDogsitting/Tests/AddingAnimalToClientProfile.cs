using NUnit.Framework;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using AutomaticTestingArmenianChairDogsitting.Steps;
using AutomaticTestingArmenianChairDogsitting.Support;
using AutomaticTestingArmenianChairDogsitting.Support.Mappers;
using AutomaticTestingArmenianChairDogsitting.Tests.TestSources.AnimalTestSources;

namespace AutomaticTestingArmenianChairDogsitting.Tests
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
            };
            _clientId = _clientSteps.RegisterClient(_clientModel);

            AuthRequestModel authModel = _authMapper.MappClientRegistrationRequestModelToAuthRequestModel(_clientModel);
            _token = _authorization.Authorize(authModel);
        }
        [TearDown]
        public void TearDown()
        {
            _clearingTables.ClearAllDB();
        }

        [TestCaseSource(typeof(AddingAnimalToClientProfile_WhenAnimalModelIsCorrect_TestSource))]
        public void AddingAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldAddingAnimalToClientProfile(AnimalRegistrationRequestModel animalModel)
        {
            int animalId  = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel(animalModel, animalId);
            _clientSteps.GetAllInfoAnimalById(animalId, _token, expectedAnimal);

            _clientSteps.GetAnimalsByClientId(_clientId, _token, expectedAnimal);

            _clientSteps.GetAnimalsByClientIdToProfile(_clientId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(AddingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_TestSource))]
        public void AddingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldAddingAnimalToClientProfileWithPropertyBreedIsLarge(AnimalRegistrationRequestModel animalModel)
        {
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel(animalModel, animalId);
            expectedAnimal.Breed = "Крупная";
            _clientSteps.GetAllInfoAnimalById(animalId, _token, expectedAnimal);

            _clientSteps.GetAnimalsByClientId(_clientId, _token, expectedAnimal);

            _clientSteps.GetAnimalsByClientIdToProfile(_clientId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(EditingAnimalToClientProfile_WhenAnimalModelIsCorrect_TestSourse))]
        public void EditingAnimalToClientProfile_WhenAnimalModelIsCorrect_ShouldEditingAnimalToClientProfile(AnimalRegistrationRequestModel animalModel,
            AnimalUpdateRequestModel animalUpdateModel)
        {
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            _clientSteps.UpdateAnimalById(animalId, _token, animalUpdateModel);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalUpdateRequestModelToAnimalAllInfoResponseModel(animalUpdateModel, animalId);
            _clientSteps.GetAllInfoAnimalById(animalId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(EditingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_TestSourse))]
        public void EditingAnimalToClientProfile_WhenPropertyBreedToAnimalModelIsOther_ShouldEditingAnimalToClientProfileWithPropertyBreedIsLarge(AnimalRegistrationRequestModel animalModel,
            AnimalUpdateRequestModel animalUpdateModel)
        {
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            _clientSteps.UpdateAnimalById(animalId, _token, animalUpdateModel);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalUpdateRequestModelToAnimalAllInfoResponseModel(animalUpdateModel, animalId);
            expectedAnimal.Breed = "Крупная";
            _clientSteps.GetAllInfoAnimalById(animalId, _token, expectedAnimal);
        }

        [TestCaseSource(typeof(DeleteAnimalToClientProfile_WhenAnimalIdIsCorrect_TestSource))]
        public void DeleteAnimalToClientProfile_WhenAnimalIdIsCorrect_ShouldDeleteAnimalToClientProfile(AnimalRegistrationRequestModel animalModel)
        {
            int animalId = _clientSteps.RegisterAnimalToClientProfile(animalModel);

            _clientSteps.DeleteAnimalById(animalId, _token);

            AnimalAllInfoResponseModel expectedAnimal = _animalMappers.MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel(animalModel, animalId);
            expectedAnimal.IsDeleted = true;
            _clientSteps.GetAllInfoAnimalById(animalId, _token, expectedAnimal);

            _clientSteps.GetAnimalsByClientId(_clientId, _token, expectedAnimal);

            _clientSteps.GetAnimalsByClientIdToProfile(_clientId, _token, expectedAnimal);
        }
    }
}
