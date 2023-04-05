using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class AddressReq
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("quarter")]
        public string Quarter { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("batch")]
        public string Batch { get; set; }
        [JsonProperty("codepostal")]
        public string Postal_Code { get; set; }
    }
}
