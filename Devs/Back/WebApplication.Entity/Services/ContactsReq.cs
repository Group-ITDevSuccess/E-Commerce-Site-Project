using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class ContactsReq
    {
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
    }
}
