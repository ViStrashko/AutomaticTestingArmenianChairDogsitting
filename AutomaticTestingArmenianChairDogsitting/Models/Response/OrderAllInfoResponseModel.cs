using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class OrderAllInfoResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("clienId")]
        public int ClienId { get; set; }

        [JsonPropertyName("sitterId")]
        public int SitterId { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("workDate")]
        public DateTime WorkDate { get; set; }

        [JsonPropertyName("dateUpdated")]
        public DateTime DateUpdated { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("district")]
        public int District { get; set; }

        [JsonPropertyName("dayQuantity")]
        public int? DayQuantity { get; set; }

        [JsonPropertyName("walkPerDayQuantity")]
        public int? WalkPerDayQuantity { get; set; }

        [JsonPropertyName("visitQuantity")]
        public int? VisitQuantity { get; set; }

        [JsonPropertyName("isTrial")]
        public bool IsTrial { get; set; }

        [JsonPropertyName("animals")]
        public List<ClientsAnimalsResponseModel> Animals { get; set; }

        [JsonPropertyName("comments")]
        public List<CommentAllInfoResponseModel> Comments { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is OrderAllInfoResponseModel))
            {
                return false;
            }
            List<ClientsAnimalsResponseModel> animals = ((OrderAllInfoResponseModel)obj).Animals;
            if (animals.Count != this.Animals.Count)
            {
                return false;
            }
            for (int i = 0; i < animals.Count; i++)
            {
                if (!animals[i].Equals(this.Animals[i]))
                {
                    return false;
                }
            }
            List<CommentAllInfoResponseModel> comments = ((OrderAllInfoResponseModel)obj).Comments;
            if (comments.Count != this.Comments.Count)
            {
                return false;
            }
            for (int i = 0; i < comments.Count; i++)
            {
                if (!comments[i].Equals(this.Comments[i]))
                {
                    return false;
                }
            }
            return obj is OrderAllInfoResponseModel model &&
                   Id == model.Id &&
                   ClienId == model.ClienId &&
                   SitterId == model.SitterId &&
                   Type == model.Type &&
                   Status == model.Status &&
                   Price == model.Price &&
                   WorkDate == model.WorkDate &&
                   DateUpdated == model.DateUpdated &&
                   Address == model.Address &&
                   District == model.District &&
                   DayQuantity == model.DayQuantity &&
                   WalkPerDayQuantity == model.WalkPerDayQuantity &&
                   VisitQuantity == model.VisitQuantity &&
                   IsTrial == model.IsTrial &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
