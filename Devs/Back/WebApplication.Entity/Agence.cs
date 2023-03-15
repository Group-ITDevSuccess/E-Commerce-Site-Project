using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class Agence : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Denomination { get; set; }
        [JsonIgnore]
        public virtual IList<Cards> Cards { get; set; }
    }
}
