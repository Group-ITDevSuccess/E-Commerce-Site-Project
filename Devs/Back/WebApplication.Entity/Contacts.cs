using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class Contacts : Entity
    {
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        [JsonIgnore]
        public virtual Clients Client { get; set; }
    }
}
