using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class OrderMappers
    {
        public OrderAllInfoResponseModel MappOrderRegistrationRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, DateTime dateUpdated, decimal price, List<ClientsAnimalsResponseModel> animals, OrderWalkRegistrationRequestModel model, int status = 1)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderWalkRegistrationRequestModel, OrderAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.DateUpdated = dateUpdated;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsDeleted = false;
            return responseModel;
        }
        public OrderUpdateRequestModel MappOrderRegistrationRequestModelToOrderUpdateRequestModel
            (DateTime date, OrderWalkRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderWalkRegistrationRequestModel, OrderUpdateRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderUpdateRequestModel>(model);
            responseModel.WorkDate = date;
            return responseModel;
        }
    }
}
