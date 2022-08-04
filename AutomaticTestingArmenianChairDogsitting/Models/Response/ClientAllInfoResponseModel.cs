using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Response
{
    public class ClientAllInfoResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("registrationDate")]
        public DateTime RegistrationDate { get; set; }

        [JsonPropertyName("dogs")]
        public List<ClientsAnimalsResponseModel> Dogs { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ClientAllInfoResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Phone == model.Phone &&
                   Address == model.Address &&
                   Email == model.Email &&
                   RegistrationDate == model.RegistrationDate &&
                   EqualityComparer<List<ClientsAnimalsResponseModel>>.Default.Equals(Dogs, model.Dogs) &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
