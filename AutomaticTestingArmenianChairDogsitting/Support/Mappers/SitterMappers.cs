using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class SitterMappers
    {
        public SitterAllInfoResponseModel MappSitterRegistrationRequestModelToSitterAllInfoResponseModel(int id, SitterRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterRegistrationRequestModel, SitterAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SitterAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.PriceCatalog = null;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public SitterAllInfoResponseModel MappSitterUpdateRequestModelToSitterAllInfoResponseModel(int id, SitterUpdateRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterUpdateRequestModel, SitterAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SitterAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.PriceCatalog = null;
            responseModel.IsDeleted = false;
            return responseModel;
        }
    }
}
