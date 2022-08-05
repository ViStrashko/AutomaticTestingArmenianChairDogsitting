using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class PriceCatalogResponseModel
    {
        [JsonPropertyName("service")]
        public int Service { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PriceCatalogResponseModel model &&
                   Service == model.Service &&
                   Price == model.Price;
        }
    }
}
