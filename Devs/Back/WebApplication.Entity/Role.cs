using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity
{
    public class Role : Entity
    {
        public virtual UserRoleEnum Nom { get; set; }
        public virtual string Description { get; set; }
        [JsonIgnore]
        public virtual IList<Users> User { get; set; }
    }
}
