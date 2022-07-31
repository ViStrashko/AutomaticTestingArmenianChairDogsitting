using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
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

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("animals")]
        public List<AnimalAllInfoResponseModel> Animals { get; set; }

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
                   Date == model.Date &&
                   Address == model.Address &&
                   EqualityComparer<List<AnimalAllInfoResponseModel>>.Default.Equals(Animals, model.Animals) &&
                   EqualityComparer<List<CommentAllInfoResponseModel>>.Default.Equals(Comments, model.Comments) &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
