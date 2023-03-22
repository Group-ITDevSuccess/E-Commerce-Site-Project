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
        public DateTime DateCreation { get; set; }
        public virtual CardTypes CardType { get; set; }

        public bool IsPasswordCorrect(CardsReq request)
        {
            return PassWord == request.PassWord;
        }

    }
}
