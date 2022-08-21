using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class OrderWalkRegistrationRequestModel
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

        [JsonPropertyName("isTrial")]
        public bool IsTrial { get; set; }
                
        public int Type
        {   get 
            {
                return 4;
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
