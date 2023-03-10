using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity
{
    public class Cards : Entity
    {
        public virtual CardTypeEnum CardType { get; set; }
    }
}
