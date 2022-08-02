using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class AnimalMappers
    {
        public AnimalAllInfoResponseModel MappAnimalRegistrationRequestModelToAnimalAllInfoResponseModel(AnimalRegistrationRequestModel model, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnimalRegistrationRequestModel, AnimalAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<AnimalAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public AnimalAllInfoResponseModel MappAnimalUpdateRequestModelToAnimalAllInfoResponseModel(AnimalUpdateRequestModel model, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnimalUpdateRequestModel, AnimalAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<AnimalAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.IsDeleted = false;
            return responseModel;
        }
    }
}
