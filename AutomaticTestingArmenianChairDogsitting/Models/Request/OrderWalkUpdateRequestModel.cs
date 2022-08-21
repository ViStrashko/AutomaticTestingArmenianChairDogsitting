using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class OrderWalkUpdateRequestModel
    {
        [JsonPropertyName("workDate")]
        public DateTime WorkDate { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("district")]
        public int District { get; set; }

        [JsonPropertyName("animalIds")]
        public List<int> AnimalIds { get; set; }

        [JsonPropertyName("isTrial")]
        public bool IsTrial { get; set; }
    }
}
