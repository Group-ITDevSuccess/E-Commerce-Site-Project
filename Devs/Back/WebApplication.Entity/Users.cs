using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class Users : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Pseudo { get; set; }
        public virtual string Email { get; set; }   
        public virtual string PassWord { get; set; }
        public virtual IList<InfoUsers> Info { get; set; }

    }
}
