using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BL.Api.V1.Models.Authentiacation
{
    public class LoginCredentials
    {
        [Required]
        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
