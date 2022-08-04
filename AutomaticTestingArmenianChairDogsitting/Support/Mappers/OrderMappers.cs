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
            (OrderRegistrationRequestModel model, int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderRegistrationRequestModel, OrderAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.Date = date;
            responseModel.Price = price;
            responseModel.Status = 0;
            responseModel.Animals = animals;
            responseModel.Comments = null;
            responseModel.IsDeleted = false;
            return responseModel;
        }
    }
}
