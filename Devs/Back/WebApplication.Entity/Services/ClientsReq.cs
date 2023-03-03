using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class ClientsReq
    {
        public virtual string FirstNameClient { get; set; }
        public virtual string LastNameClient { get; set; }
        public virtual DateTime BirthDayClient { get; set; }
        public virtual bool GenreClient { get; set; }
    }
}
