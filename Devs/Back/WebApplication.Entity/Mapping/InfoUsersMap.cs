using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class InfoUsersMap : SubclassMap<InfoUsers>
    {
        public InfoUsersMap()
        {
            Abstract();
            Map(x => x.Contact).Not.Nullable();
            Map(x => x.Mail).Not.Nullable();
            Map(x => x.Web).Nullable();

            References(x => x.User)
                .Column("UserId")
                .Cascade.None()
                .Not.LazyLoad();
        }
    }
}
