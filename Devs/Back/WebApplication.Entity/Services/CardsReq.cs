using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity.Services
{
    class CardsReq
    {
        public CardTypeEnum CardType { get; set; }
        public string Description { get; set; }
    }
}
