using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class SittersGetAllResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("experience")]
        public int Experience { get; set; }


        public override bool Equals(object? obj)
        {
            return obj is SitterAllInfoResponseModel model &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Experience == model.Experience;
        }

    }
}
