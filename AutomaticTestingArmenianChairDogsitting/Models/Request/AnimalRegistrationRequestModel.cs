using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class AnimalRegistrationRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("recommendationsForCare")]
        public string RecommendationsForCare { get; set; }

        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }

        [JsonPropertyName("breed")]
        public string Breed { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age} {RecommendationsForCare} {ClientId} {Breed} {Size}";
        }
    }
}
