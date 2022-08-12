using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class PriceCatalogRequestModel
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
