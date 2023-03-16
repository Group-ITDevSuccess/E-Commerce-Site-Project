using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity
{
    public class CardTypes : Entity
    {
        public virtual CardTypeEnum CardType { get; set; }
        /*[JsonIgnore]
        public virtual IList<Cards> Cards { get; set; }*/
    }
}
