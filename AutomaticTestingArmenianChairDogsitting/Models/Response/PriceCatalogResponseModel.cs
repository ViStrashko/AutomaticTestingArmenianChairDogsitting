using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class PriceCatalogResponseModel
    {
        [JsonPropertyName("sitterId")]
        public int SitterId { get; set; }

        [JsonPropertyName("service")]
        public int Service { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PriceCatalogResponseModel model &&
                   SitterId == model.SitterId &&
                   Service == model.Service &&
                   Price == model.Price &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
