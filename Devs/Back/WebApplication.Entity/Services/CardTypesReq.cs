using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity.Services
{
    public class CardTypesReq
    {
        [JsonProperty("cartypes")]
        public string CardTypes { get; set; }
    }
}
