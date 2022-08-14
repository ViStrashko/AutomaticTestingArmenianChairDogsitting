using System.Text.Json.Serialization;

namespace AutomaticTestingArmenianChairDogsitting.Models.Request
{
    public class ChangePasswordRequestModel
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("oldPassword")]
        public string OldPassword { get; set; }

        public override string ToString()
        {
            return $"{Password} {OldPassword}";
        }
    }
}
