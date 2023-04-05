using FluentNHibernate.Mapping;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class StocksReq
    {
        [JsonProperty("quantity")]
        public string Quantite { get; set; }
        [JsonProperty("remarque")]
        public string Remarque { get; set; }
    }
}
