using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class SittersGetAllResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }


        [JsonPropertyName("experience")]
        public int Experience { get; set; }


        public override bool Equals(object? obj)
        {
            return obj is SitterAllInfoResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Experience == model.Experience;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {LastName} {Experience}";
        }
    }
}
