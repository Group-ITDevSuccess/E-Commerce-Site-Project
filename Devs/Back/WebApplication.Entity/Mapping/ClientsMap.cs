using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class ClientsMap : SubclassMap<Clients>
    {
        public ClientsMap()
        {
            Abstract();
            Map(x => x.FirstNameClient).Not.Nullable();
            Map(x => x.LastNameClient).Not.Nullable();
            Map(x => x.BirthDayClient).Not.Nullable();
            Map(x => x.GenreClient).Not.Nullable();
            HasMany(x => x.AddressClient)
                .Cascade.All()
                .Not.LazyLoad();
        }
    }
}
