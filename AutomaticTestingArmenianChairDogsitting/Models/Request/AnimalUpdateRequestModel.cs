using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class AnimalUpdateRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("recommendationsForCare")]
        public string RecommendationsForCare { get; set; }

        [JsonPropertyName("breed")]
        public string Breed { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
