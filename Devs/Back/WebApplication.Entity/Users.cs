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
        public virtual DateTime BirthDay { get; set; }
        public virtual bool Genre { get; set; }
        public virtual string Email { get; set; }   
        public virtual string PassWord { get; set; }
        public virtual bool HasToken { get; set; }
        public virtual IList<Role> Role { get; set; }
        public virtual IList<Contacts> Contact { get; set; }
        public virtual Address Address { get; set; }
        public virtual Cards Card { get; set; }
    }
}
