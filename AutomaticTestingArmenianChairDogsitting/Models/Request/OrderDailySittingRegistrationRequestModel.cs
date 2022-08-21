using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class OrderDailySittingRegistrationRequestModel
    {
        [JsonPropertyName("clienId")]
        public int ClienId { get; set; }

        [JsonPropertyName("sitterId")]
        public int SitterId { get; set; }

        [JsonPropertyName("animalIds")]
        public List<int> AnimalIds { get; set; }

        [JsonPropertyName("workDate")]
        public DateTime WorkDate { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("district")]
        public int District { get; set; }

        [JsonPropertyName("dayQuantity")]
        public int DayQuantity { get; set; }

        [JsonPropertyName("walkPerDayQuantity")]
        public int WalkPerDayQuantity { get; set; }

        public int Type
        {
            get
            {
                return 1;
            }
            private set { }
        }

        public int Status
        {
            get
            {
                return 1;
            }
            private set { }
        }
    }
}
