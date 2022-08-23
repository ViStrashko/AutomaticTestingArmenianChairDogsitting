using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class SitterMappers
    {
        public SitterAllInfoResponseModel MappSitterRegistrationRequestModelToSitterAllInfoResponseModel
            (int id, DateTime date, SitterRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PriceCatalogRequestModel, PriceCatalogResponseModel>();
                cfg.CreateMap<SitterRegistrationRequestModel, SitterAllInfoResponseModel>();
            });
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SitterAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.RegistrationDate = date;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public SitterAllInfoResponseModel MappSitterUpdateRequestModelToSitterAllInfoResponseModel
            (int id, DateTime date, string email, List<PriceCatalogRequestModel> priceCatalog, SitterUpdateRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterUpdateRequestModel, SitterAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SitterAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.RegistrationDate = date;
            responseModel.Email = email;
            responseModel.PriceCatalog = MappPriceCatalogRequestModelToPriceCatalogResponseModel(priceCatalog);
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public SittersGetAllResponseModel MappSitterRegistrationModelToSittersGetAllResponseModel
            (int id, DateTime date, SitterRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterRegistrationRequestModel, SittersGetAllResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SittersGetAllResponseModel>(model);
            responseModel.Id = id;
            responseModel.RegistrationDate = date;
            return responseModel;
        }

        public SitterUpdateRequestModel MappSitterRegistrationModelToSitterUpdateRequestModel(SitterRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterRegistrationRequestModel, SitterUpdateRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<SitterUpdateRequestModel>(model);
            return responseModel;
        }

        public ChangePasswordRequestModel MappSitterRegistrationModelToChangePasswordRequestModel
            (SitterRegistrationRequestModel model, string newPassword)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SitterRegistrationRequestModel, ChangePasswordRequestModel>()
            .ForMember(pts => pts.OldPassword, opt => opt.MapFrom(o => o.Password)));
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ChangePasswordRequestModel>(model);
            responseModel.Password = newPassword;
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
