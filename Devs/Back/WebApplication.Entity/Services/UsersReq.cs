using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class UsersReq
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string PassWord { get; set; }
        [JsonProperty("birthday")]
        public DateTime BirthDay { get; set; }
        [JsonProperty("genre")]
        public bool Genre { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("card")]
        public Cards Card { get; set; }
    }
}
