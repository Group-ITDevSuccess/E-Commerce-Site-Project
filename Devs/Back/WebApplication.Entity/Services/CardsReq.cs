using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class CardsReq
    {
        public string Number { get; set; }
        public string PassWord { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CardholderName { get; set; }

        public bool IsPasswordCorrect(CardsReq request)
        {
            return PassWord == request.PassWord;
        }

    }
}
