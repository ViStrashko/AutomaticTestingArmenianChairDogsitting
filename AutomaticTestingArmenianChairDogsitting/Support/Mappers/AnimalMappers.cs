using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class AnimalMappers
    {
        public AnimalAllInfoResponseModel MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel
            (int id, AnimalRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnimalRegistrationRequestModel, AnimalAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<AnimalAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.IsDeleted = false;
            return responseModel;
        }
        public AnimalAllInfoResponseModel MappAnimalUpdateRequestModelToAnimalAllInfoResponseModel
            (int id, AnimalUpdateRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnimalUpdateRequestModel, AnimalAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<AnimalAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public ClientsAnimalsResponseModel MappAnimalRegistrationRequestModelToClientsAnimalsResponseModel
            (int id, AnimalRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnimalRegistrationRequestModel, ClientsAnimalsResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientsAnimalsResponseModel>(model);
            responseModel.Id = id;
            return responseModel;
        }

        public AnimalUpdateRequestModel MappAnimalRegistrationRequestModelToAnimalUpdateRequestModel(AnimalRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnimalRegistrationRequestModel, AnimalUpdateRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<AnimalUpdateRequestModel>(model);
            return responseModel;
        }
    }
}
