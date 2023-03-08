using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class Stocks : Entity
    {
        public virtual string Quantite { get; set; }
        public virtual string Remarque { get; set; }
        [JsonIgnore]
        public virtual IList<Products> Product { get; set; }
    }
}
