using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class OrderRegistrationRequestModel
    {
        [JsonPropertyName("clienId")]
        public int ClienId { get; set; }

        [JsonPropertyName("sitterId")]
        public int SitterId { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("animals")]
        public List<AnimalRegistrationRequestModel> Animals { get; set; }
    }
}
