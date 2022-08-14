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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PriceCatalogRequestModel, PriceCatalogResponseModel>();
                cfg.CreateMap<SitterRegistrationRequestModel, SitterAllInfoResponseModel>();
            });
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
            responseModel.PriceCatalog = MappPriceCatalogRequestModelToPriceCatalogResponseModel(priceCatalog);
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public SittersGetAllResponseModel MappSitterRegistrationModelToSittersGetAllResponseModel(int id, SitterRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterRegistrationRequestModel, SittersGetAllResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SittersGetAllResponseModel>(model);
            responseModel.Id = id;
            return responseModel;
        }

        public List<PriceCatalogResponseModel> MappPriceCatalogRequestModelToPriceCatalogResponseModel(List<PriceCatalogRequestModel> prices)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PriceCatalogRequestModel, PriceCatalogResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<List<PriceCatalogResponseModel>>(prices);
            return responseModel;
        }
    }
}
