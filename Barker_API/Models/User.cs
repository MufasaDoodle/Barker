using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Barker_API.Models
{
    public class User
    {
        [JsonPropertyName("UserID")]
        public int UserID { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Lastname")]
        public string Lastname { get; set; }
        [JsonPropertyName("Birthday")]
        public DateTime Birthday { get; set; }
        [JsonPropertyName("LastLogon")]
        public DateTime LastLogon { get; set; }
        [JsonPropertyName("AccountCreationDate")]
        public DateTime AccountCreationDate { get; set; }
    }
}
