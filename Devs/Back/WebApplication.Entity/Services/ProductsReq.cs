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
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public Brand ProductBrand { get; set; } 
        public Categories ProductCategorie { get; set; }
        public List<Stocks> Stock { get; set; }

    }
}
