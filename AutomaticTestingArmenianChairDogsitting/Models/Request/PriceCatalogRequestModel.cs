using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class PriceCatalogRequestModel
    {
        [JsonPropertyName("sitterId")]
        public int SitterId { get; set; }

        [JsonPropertyName("service")]
        public int Service { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
