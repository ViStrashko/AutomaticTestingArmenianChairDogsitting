using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class AuthMappers
    {
        public AuthRequestModel MappClientRegistrationRequestModelToAuthRequestModel(ClientRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientRegistrationRequestModel, AuthRequestModel>()
            .ForMember(o=>o.Email, opt => opt.MapFrom(c => c.Email))
            .ForMember(o => o.Password, opt => opt.MapFrom(c => c.Password)));
            Mapper mapper = new Mapper(config);
            var requestModel = mapper.Map<AuthRequestModel>(model);
            return requestModel;
        }
    }
}
