using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class OrderOverexposeUpdateRequestModel
    {
        [JsonPropertyName("workDate")]
        public DateTime WorkDate { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("district")]
        public int District { get; set; }

        [JsonPropertyName("animalIds")]
        public List<int> AnimalIds { get; set; }

        [JsonPropertyName("dayQuantity")]
        public int DayQuantity { get; set; }

        [JsonPropertyName("walkPerDayQuantity")]
        public int WalkPerDayQuantity { get; set; }
    }
}
