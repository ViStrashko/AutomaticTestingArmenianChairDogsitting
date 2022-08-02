using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class ClientMappers
    {
        public ClientAllInfoResponseModel MappClientRegistrationRequestModelToClientAllInfoResponseModel(ClientRegistrationRequestModel model, int id, DateTime date)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientRegistrationRequestModel, ClientAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.RegistrationDate = date;
            responseModel.Dogs = null;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public ClientAllInfoResponseModel MappClientUpdateRequestModelToClientAllInfoResponseModel(ClientUpdateRequestModel model, int id, DateTime date)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientUpdateRequestModel, ClientAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.RegistrationDate = date;
            responseModel.Dogs = null;
            responseModel.IsDeleted = false;
            return responseModel;
        }
    }
}
