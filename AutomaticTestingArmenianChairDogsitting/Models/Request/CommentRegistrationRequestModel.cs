using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class CommentRegistrationRequestModel
    {
        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Rating} {Text}";
        }
    }
}
