using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class AccountReq
    {
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
