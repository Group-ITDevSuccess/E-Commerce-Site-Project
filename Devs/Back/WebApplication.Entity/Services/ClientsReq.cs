using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class ClientsReq
    {
        public string FirstNameClient { get; set; }
        public string LastNameClient { get; set; }
        public DateTime BirthDayClient { get; set; }
        public bool GenreClient { get; set; }
        public AddressClients AddressClient {get; set;}
        public Accounts AccountClient { get; set;}
        public Cards Card { get; set;}
    }
}
