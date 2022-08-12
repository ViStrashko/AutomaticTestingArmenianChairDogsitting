using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class CommentMappers
    {
        public CommentAllInfoResponseModel MappCommentRegistrationRequestModelToCommentAllInfoResponseModel
            (int id, int orderId, CommentRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentRegistrationRequestModel, CommentAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<CommentAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.OrderId = orderId;
            responseModel.IsClient = true;
            responseModel.IsDeleted = false;
            return responseModel;
        }
    }
}
