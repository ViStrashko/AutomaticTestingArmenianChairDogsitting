using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class SitterMappers
    {
        public SitterAllInfoResponseModel MappSitterRegistrationRequestModelToSitterAllInfoResponseModel
            (int id, SitterRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterRegistrationRequestModel, SitterAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SitterAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public SitterAllInfoResponseModel MappSitterUpdateRequestModelToSitterAllInfoResponseModel
            (int id, string email, List<PriceCatalogRequestModel> priceCatalog, SitterUpdateRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterUpdateRequestModel, SitterAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SitterAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.Email = email;
            responseModel.PriceCatalog = MappPriceCatalogRequestModelToPriceCatalogRequestModel(priceCatalog);
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public SittersGetAllResponse MappSitterRegistrationModelToSittersGetAllResponse(int id, SitterRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterRegistrationRequestModel, SittersGetAllResponse>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SittersGetAllResponse>(model);
            responseModel.Id = id;
            return responseModel;
        }

        public List<PriceCatalogResponseModel> MappPriceCatalogRequestModelToPriceCatalogRequestModel(List<PriceCatalogRequestModel> prices)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<List<PriceCatalogRequestModel>, List<PriceCatalogResponseModel>>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<List<PriceCatalogResponseModel>>(prices);
            return responseModel;
        }


    }
}
