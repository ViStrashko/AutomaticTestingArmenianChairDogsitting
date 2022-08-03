using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class CommentResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CommentResponseModel model &&
                   Id == model.Id &&
                   Rating == model.Rating &&
                   Text == model.Text;
        }
    }
}
