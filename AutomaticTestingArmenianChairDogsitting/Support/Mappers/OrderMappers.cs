using AutoMapper;
using AutomaticTestingArmenianChairDogsitting.Models.Request;
using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;
using System.Collections.Generic;

namespace AutomaticTestingArmenianChairDogsitting.Support.Mappers
{
    public class OrderMappers
    {
        public OrderAllInfoResponseModel MappOrderWalkRegistrationRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals, OrderWalkRegistrationRequestModel model,
            int status)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderWalkRegistrationRequestModel, OrderAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.DateUpdated = date;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.DayQuantity = null;
            responseModel.WalkPerDayQuantity = null;
            responseModel.VisitQuantity = null;            
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public OrderAllInfoResponseModel MappOrderOverexposeRegistrationRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals, OrderOverexposeRegistrationRequestModel model,
            int status)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderOverexposeRegistrationRequestModel, OrderAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.DateUpdated = date;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.VisitQuantity = null;
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsTrial = false;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public OrderAllInfoResponseModel MappOrderDailySittingRegistrationRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals, OrderDailySittingRegistrationRequestModel model,
            int status)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDailySittingRegistrationRequestModel, OrderAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.DateUpdated = date;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.VisitQuantity = null;
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsTrial = false;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public OrderAllInfoResponseModel MappOrderSittingForADayRegistrationRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals, OrderSittingForADayRegistrationRequestModel model,
            int status)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderSittingForADayRegistrationRequestModel, OrderAllInfoResponseModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.DateUpdated = date;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.DayQuantity = null;
            responseModel.WalkPerDayQuantity = null;
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsTrial = false;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public OrderAllInfoResponseModel MappOrderWalkUpdateRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals, OrderWalkUpdateRequestModel model,
            int status, int type)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderWalkUpdateRequestModel, OrderAllInfoResponseModel>()
            .ForMember(pts => pts.DateUpdated, opt => opt.MapFrom(o => o.WorkDate)));
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.Type = type;
            responseModel.DayQuantity = null;
            responseModel.WalkPerDayQuantity = null;
            responseModel.VisitQuantity = null;            
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public OrderAllInfoResponseModel MappOrderOverexposeUpdateRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals, OrderOverexposeUpdateRequestModel model,
            int status, int type)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderOverexposeUpdateRequestModel, OrderAllInfoResponseModel>()
            .ForMember(pts => pts.DateUpdated, opt => opt.MapFrom(o => o.WorkDate)));
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.Type = type;
            responseModel.VisitQuantity = null;
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsTrial = false;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public OrderAllInfoResponseModel MappOrderDailySittingUpdateRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals, OrderDailySittingUpdateRequestModel model,
            int status, int type)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDailySittingUpdateRequestModel, OrderAllInfoResponseModel>()
            .ForMember(pts => pts.DateUpdated, opt => opt.MapFrom(o => o.WorkDate)));
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.Type = type;
            responseModel.VisitQuantity = null;
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsTrial = false;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public OrderAllInfoResponseModel MappOrderSittingForADayUpdateRequestModelToOrderAllInfoResponseModel
            (int id, DateTime date, decimal price, List<ClientsAnimalsResponseModel> animals, OrderSittingForADayUpdateRequestModel model,
            int status, int type)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderSittingForADayUpdateRequestModel, OrderAllInfoResponseModel>()
            .ForMember(pts => pts.DateUpdated, opt => opt.MapFrom(o => o.WorkDate)));
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderAllInfoResponseModel>(model);
            responseModel.Id = id;
            responseModel.WorkDate = date;
            responseModel.Price = price;
            responseModel.Status = status;
            responseModel.Type = type;
            responseModel.DayQuantity = null;
            responseModel.WalkPerDayQuantity = null;
            responseModel.Animals = animals;
            responseModel.Comments = new List<CommentAllInfoResponseModel>();
            responseModel.IsTrial = false;
            responseModel.IsDeleted = false;
            return responseModel;
        }

        public OrderWalkUpdateRequestModel MappOrderWalkRegistrationRequestModelToOrderWalkUpdateRequestModel
            (DateTime date, OrderWalkRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderWalkRegistrationRequestModel, OrderWalkUpdateRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderWalkUpdateRequestModel>(model);
            responseModel.WorkDate = date;
            return responseModel;
        }

        public OrderOverexposeUpdateRequestModel MappOrderOverexposeRegistrationRequestModelToOrderOverexposeUpdateRequestModel
            (DateTime date, OrderOverexposeRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderOverexposeRegistrationRequestModel, OrderOverexposeUpdateRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderOverexposeUpdateRequestModel>(model);
            responseModel.WorkDate = date;
            return responseModel;
        }

        public OrderDailySittingUpdateRequestModel MappOrderDailySittingRegistrationRequestModelToOrderDailySittingUpdateRequestModel
            (DateTime date, OrderDailySittingRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDailySittingRegistrationRequestModel, OrderDailySittingUpdateRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderDailySittingUpdateRequestModel>(model);
            responseModel.WorkDate = date;
            return responseModel;
        }

        public OrderSittingForADayUpdateRequestModel MappOrderSittingForADayRegistrationRequestModelToOrderSittingForADayUpdateRequestModel
            (DateTime date, OrderSittingForADayRegistrationRequestModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderSittingForADayRegistrationRequestModel, OrderSittingForADayUpdateRequestModel>());
            Mapper mapper = new Mapper(config);
            var responseModel = mapper.Map<OrderSittingForADayUpdateRequestModel>(model);
            responseModel.WorkDate = date;
            return responseModel;
        }
    }
}
