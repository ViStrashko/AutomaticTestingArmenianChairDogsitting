using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class SitterAllInfoResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("experience")]
        public int Experience { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("sex")]
        public int Sex { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("priceCatalog")]
        public List<PriceCatalogResponseModel> PriceCatalog { get; set; }

        [JsonPropertyName("registrationDate")]
        public DateTime RegistrationDate { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null|| !(obj is SitterAllInfoResponseModel))
            {
                return false;
            }
            List<PriceCatalogResponseModel> prices = ((SitterAllInfoResponseModel)obj).PriceCatalog;
            if(prices.Count != this.PriceCatalog.Count)
            {
                return false;
            }
            for (int i =0; i<prices.Count; i++)
            {
                if(!prices[i].Equals(this.PriceCatalog[i]))
                {
                    return false;
                }
            }
            return obj is SitterAllInfoResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Phone == model.Phone &&
                   Age == model.Age &&
                   Experience == model.Experience &&
                   Description == model.Description &&
                   Sex == model.Sex &&
                   Email == model.Email &&
                   RegistrationDate.Date == model.RegistrationDate.Date &&
                   IsDeleted == model.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {LastName} {Phone} {Age} {Experience} {Description} {Sex} {Email} {RegistrationDate} {IsDeleted}";
        }
    }
}
