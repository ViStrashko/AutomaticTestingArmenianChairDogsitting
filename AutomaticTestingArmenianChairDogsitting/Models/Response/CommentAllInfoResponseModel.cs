using System;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class CommentAllInfoResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("timeCreated")]
        public DateTime TimeCreated { get; set; }

        [JsonPropertyName("timeUpdated")]
        public DateTime TimeUpdated { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CommentAllInfoResponseModel model &&
                   Id == model.Id &&
                   Rating == model.Rating &&
                   Text == model.Text &&
                   TimeCreated == model.TimeCreated &&
                   TimeUpdated == model.TimeUpdated &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
