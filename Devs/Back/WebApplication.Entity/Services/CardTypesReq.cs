using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity.Services
{
    class CardTypesReq
    {
        public List<CardTypeEnum> CardType { get; set; }
    }
}
