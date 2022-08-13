using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class PriceCatalogUpdateModel
    {
        [JsonPropertyName("priceCatalog")]
        public List<PriceCatalogRequestModel> PriceCatalog { get; set; }
    }
}
