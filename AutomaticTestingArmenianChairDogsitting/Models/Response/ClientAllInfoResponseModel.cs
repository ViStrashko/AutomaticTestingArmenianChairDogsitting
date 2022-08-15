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

        [JsonPropertyName("orders")]
        public List<OrderAllInfoResponseModel> Orders { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is ClientAllInfoResponseModel))
            {
                return false;
            }
            List<ClientsAnimalsResponseModel> dogs = ((ClientAllInfoResponseModel)obj).Dogs;
            if (dogs.Count != this.Dogs.Count)
            {
                return false;
            }
            for (int i = 0; i < dogs.Count; i++)
            {
                if (!dogs[i].Equals(this.Dogs[i]))
                {
                    return false;
                }
            }
            List<OrderAllInfoResponseModel> orders = ((ClientAllInfoResponseModel)obj).Orders;
            if (orders.Count != this.Orders.Count)
            {
                return false;
            }
            for (int i = 0; i < orders.Count; i++)
            {
                if (!orders[i].Equals(this.Orders[i]))
                {
                    return false;
                }
            }
            return obj is ClientAllInfoResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Phone == model.Phone &&
                   Address == model.Address &&
                   Email == model.Email &&
                   RegistrationDate.Date == model.RegistrationDate.Date &&
                   IsDeleted == model.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {LastName} {Phone} {Address} {Email} {RegistrationDate} {IsDeleted}";
        }
    }
}
