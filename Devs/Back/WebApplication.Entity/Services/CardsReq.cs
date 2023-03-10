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
        public List<CardTypeEnum> CardType { get; set; }
    }
}
