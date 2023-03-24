using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class InfoUsers : Entity
    {
        public virtual string Contact { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Web { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }
    }
}
