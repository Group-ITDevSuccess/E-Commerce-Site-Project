using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class AgenceReq
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("denomination")]
        public string Denomination { get; set; }
    }
}
