using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class SearchRequestModel
    {
        [JsonPropertyName("priceMinimum")]
        public int? PriceMinimum { get; set; }

        [JsonPropertyName("priceMaximum")]
        public int? PriceMaximum { get; set; }

        [JsonPropertyName("minRating")]
        public int? MinRating { get; set; }

        [JsonPropertyName("isSitterHasComments")]
        public bool IsSitterHasComments { get; set; }

        [JsonPropertyName("serviceType")]
        public int ServiceType { get; set; }

        [JsonPropertyName("district")]
        public int? District { get; set; }
    }
}
