using Newtonsoft.Json;
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
        public virtual DateTime DateCreation { get; set; } = DateTime.Now;
        
    }
}
