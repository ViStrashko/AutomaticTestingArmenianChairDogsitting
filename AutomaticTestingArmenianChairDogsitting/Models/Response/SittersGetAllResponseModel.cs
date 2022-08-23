using System;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class SittersGetAllResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("experience")]
        public int Experience { get; set; }

        [JsonPropertyName("registrationDate")]
        public DateTime RegistrationDate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is SittersGetAllResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Experience == model.Experience &&
                   RegistrationDate.Date == model.RegistrationDate.Date;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {LastName} {Experience} {RegistrationDate}";
        }
    }
}
