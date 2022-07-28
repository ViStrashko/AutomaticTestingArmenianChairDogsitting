using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class PriceCatalogResponsModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("service")]
        public int Service { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
