using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity
{
    public class BankAccount : Entity
    {
        public virtual IList<Cards> CardTypes { get; set; }
        public virtual string PassWord { get; set; }

        public virtual string BankCode
        {
            get { return string.Format("{0}-{1}", CardTypes, PassWord.GetHashCode()); }
        }
    }
}
