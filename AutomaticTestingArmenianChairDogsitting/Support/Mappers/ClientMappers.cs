using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class ClientMappers
    {
        public ClientAllInfoResponseModel MappClientRegistrationRequestModelToClientAllInfoResponseModel(ClientRegistrationRequestModel model, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientRegistrationRequestModel, ClientAllInfoResponseModel>()
            .ForMember(o => o.Name, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.LastName, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.Phone, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.Address, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.Email, opt => opt.MapFrom(c => c.Email)));
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.RegistrationDate = DateTime.Now.Date;
            responseModel.Dogs = null;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public ClientAllInfoResponseModel MappClientUpdateRequestModelToClientAllInfoResponseModel(ClientUpdateRequestModel model, int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientUpdateRequestModel, ClientAllInfoResponseModel>()
            .ForMember(o => o.Name, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.LastName, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.Phone, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.Address, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.Email, opt => opt.MapFrom(c => c.Email)));
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<ClientAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.RegistrationDate = DateTime.Now.Date;
            responseModel.Dogs = null;
            responseModel.IsDeleted = false;
            return responseModel;
        }
    }
}
