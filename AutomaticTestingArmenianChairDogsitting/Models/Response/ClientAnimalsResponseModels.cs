using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class ClientAnimalsResponseModels
    {
        [JsonPropertyName("dogs")]
        public List<AnimalAllInfoResponseModel> Dogs { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ClientAnimalsResponseModels models &&
                   EqualityComparer<List<AnimalAllInfoResponseModel>>.Default.Equals(Dogs, models.Dogs);
        }
    }
}
