using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;


namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class SittersMapper
    {
        //private static Mapper _instance;

        //public static Mapper GetInstance()
        //{
        //    if (_instance == null)
        //        InitializeInstance();
        //    return _instance;
        //}

        //private static void InitializeInstance()
        //{
        //    _instance = new Mapper(new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<AuthRequestModel, SitterRegistrationRequestModel>();
        //    }));
        //}
        public AuthRequestModel MapSitterRegistModelToAuthModel(SitterRegistrationRequestModel sitter)
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthRequestModel, SitterRegistrationRequestModel>());
            //Mapper mapper = new Mapper(config);
            //var responseModel = mapper.Map<AuthRequestModel>(sitter);
            //return responseModel;
            AuthRequestModel authRequestModel = new AuthRequestModel();
            authRequestModel.Email = sitter.Email;
            authRequestModel.Password = sitter.Password;
            return authRequestModel;
        }
        public SittersGetAllResponse MapSitterRegistModelToSitterGetAllResponse(SitterRegistrationRequestModel sitter, int id)
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<SittersGetAllResponse, SitterRegistrationRequestModel>());
            //Mapper mapper = new Mapper(config);
            //SittersGetAllResponse responseModel = mapper.Map<SittersGetAllResponse>(sitter);
            SittersGetAllResponse responseModel = new SittersGetAllResponse();
            responseModel.Name = sitter.Name;
            responseModel.Experience = sitter.Experience;
            responseModel.LastName = sitter.LastName;
            //responseModel.Id = id;
            responseModel.Id = 0;
            return responseModel;
        }
    }
}
