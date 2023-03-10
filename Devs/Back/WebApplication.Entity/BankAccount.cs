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
        public virtual string Intituler { get; set; }
        /*
        public virtual DateTime DateCreation { get; set; }


        public BankAccount()
        {
            DateCreation = DateTime.Now;
        }

        public virtual string BankCode
        {
            get { return string.Format("{0}-{1}", Intituler, PassWord.GetHashCode()); }
        }*/
    }
}
