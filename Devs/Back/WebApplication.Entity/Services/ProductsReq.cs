using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class ProductsReq
    {
        [JsonProperty("productname")]
        public string ProductName { get; set; }
        [JsonProperty("productprice")]
        public string ProductPrice { get; set; }
        [JsonProperty("productdescription")]
        public string ProductDescription { get; set; }
        [JsonProperty("productbrand")]
        public Brand ProductBrand { get; set; }
        [JsonProperty("productcategorie")]
        public Categories ProductCategorie { get; set; }
        [JsonProperty("stock")]
        public List<Stocks> Stock { get; set; }

    }
}
