using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    class BankAccountReq
    {
        [JsonProperty("intituler")]
        public string Intituler { get; set; }
    }
}
