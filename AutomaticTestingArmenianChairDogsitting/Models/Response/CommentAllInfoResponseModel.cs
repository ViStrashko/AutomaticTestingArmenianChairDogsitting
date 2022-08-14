using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class CommentAllInfoResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("isClient")]
        public bool IsClient { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CommentAllInfoResponseModel model &&
                   Id == model.Id &&
                   OrderId == model.OrderId &&
                   Rating == model.Rating &&
                   Text == model.Text &&
                   IsClient == model.IsClient &&
                   IsDeleted == model.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {OrderId} {Rating} {Text} {IsClient} {IsDeleted}";
        }
    }
}
