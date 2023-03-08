using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class AddressClientsReq
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Quarter { get; set; }
        public string Street { get; set; }
        public string Batch { get; set; }
        public string Postal_Code { get; set; }
    }
}
