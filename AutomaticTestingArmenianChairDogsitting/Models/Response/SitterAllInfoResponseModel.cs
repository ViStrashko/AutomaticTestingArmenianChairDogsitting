using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class SitterAllInfoResponseModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("experience")]
        public int Experience { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("sex")]
        public int Sex { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("priceCatalogResponsModel")]
        public PriceCatalogResponsModel PriceCatalog { get; set; }


    }
}
