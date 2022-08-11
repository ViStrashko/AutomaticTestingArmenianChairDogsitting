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

        [JsonPropertyName("animals")]
        public List<ClientsAnimalsResponseModel> Animals { get; set; }

        [JsonPropertyName("comments")]
        public List<CommentAllInfoResponseModel> Comments { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
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
                   EqualityComparer<List<ClientsAnimalsResponseModel>>.Default.Equals(Animals, model.Animals) &&
                   EqualityComparer<List<CommentAllInfoResponseModel>>.Default.Equals(Comments, model.Comments) &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
