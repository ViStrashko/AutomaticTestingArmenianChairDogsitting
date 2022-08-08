using AutomaticTestingArmenianChairDogsitting.Models.Response;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class PriceCatalogRequestModel
    {
        [JsonPropertyName("priceCatalog")]
        public List<PriceCatalogResponseModel> PriceCatalog { get; set; }
    }
}
