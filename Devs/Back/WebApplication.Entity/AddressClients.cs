using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class AddressClients : Entity
    {
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual string Quarter { get; set; }
        public virtual string Street { get; set; }
        public virtual string Batch { get; set; }
        public virtual string Postal_Code { get; set; }

    }
}
