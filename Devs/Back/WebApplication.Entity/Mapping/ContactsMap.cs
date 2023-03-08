using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class ContactsMap : SubclassMap<Contacts>
    {
        public ContactsMap()
        {
            Abstract();
            Map(x => x.Phone).Not.Nullable();
            Map(x => x.Email).Not.Nullable();

            /*HasMany<Clients>(x => x.Client)
                .Cascade.All()
                .Not.LazyLoad();*/
            References(x => x.Client)
            .Column("ClientId")
            .Cascade.None()
            .Not.LazyLoad();
        }
    }
}
