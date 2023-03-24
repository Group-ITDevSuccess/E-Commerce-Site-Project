using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class AccountMap : SubclassMap<Accounts>
    {
        public AccountMap()
        {
            Abstract();
            Map(x => x.Pseudo).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.PassWord).Not.Nullable();

            References(x => x.Client)
            .Column("ClientId")
            .Cascade.None()
            .Not.LazyLoad();
        }
    }
}
