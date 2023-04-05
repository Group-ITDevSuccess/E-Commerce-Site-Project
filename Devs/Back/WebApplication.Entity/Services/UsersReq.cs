using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class UsersReq
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Genre { get; set; }
        public AddressClients Address { get; set; }
        public Cards Card { get; set; }
    }
}
