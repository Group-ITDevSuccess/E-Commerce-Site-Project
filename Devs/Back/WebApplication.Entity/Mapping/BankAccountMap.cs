using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    public class BankAccountMap : SubclassMap<BankAccount>
    {
        public BankAccountMap()
        {
            Abstract();
            Map(x => x.CardTypes).Not.Nullable();
            Map(x => x.PassWord).Not.Nullable();
            Map(x => x.BankCode)
                .Formula("CardTypes + '-' + CONVERT(NVARCHAR(20), HASHBYTES('MD5', PassWord), 2)");
        }
    }   
}
