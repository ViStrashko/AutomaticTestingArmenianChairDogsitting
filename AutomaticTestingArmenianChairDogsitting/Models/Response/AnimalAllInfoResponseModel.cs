using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class AnimalAllInfoResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

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

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is AnimalAllInfoResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Age == model.Age &&
                   RecommendationsForCare == model.RecommendationsForCare &&
                   Breed == model.Breed &&
                   Size == model.Size &&
                   IsDeleted == model.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Age} {RecommendationsForCare} {Breed} {Size} {IsDeleted}";
        }
    }
}
