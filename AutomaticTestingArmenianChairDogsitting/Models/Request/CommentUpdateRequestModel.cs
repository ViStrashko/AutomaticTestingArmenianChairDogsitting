using System;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class CommentUpdateRequestModel
    {
        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("timeUpdated")]
        public DateTime TimeUpdated { get; set; }
    }
}
