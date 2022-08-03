using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class ClientsAnimalsResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("breed")]
        public string Breed { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is AnimalAllInfoResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Breed == model.Breed;
        }
    }
}
