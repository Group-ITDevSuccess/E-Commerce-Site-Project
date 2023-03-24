using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class Accounts : Entity
    {
        public virtual string Pseudo { get; set; }
        public virtual string Email { get; set; }
        public virtual string PassWord { get; set; }
        [JsonIgnore]
        public virtual Clients Client { get; set; }
    }
}
