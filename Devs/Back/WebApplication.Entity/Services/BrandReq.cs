using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class BrandReq
    {
        [JsonProperty("brandname")]
        public string BrandName { get; set; }
    }
}
