using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class AddressClientsMap : SubclassMap<AddressClients>
    {
        public AddressClientsMap()
        {
            Abstract();
            Map(x => x.City).Not.Nullable();
            Map(x => x.Country).Not.Nullable();
            Map(x => x.Quarter).Not.Nullable();
            Map(x => x.Street).Not.Nullable();
            Map(x => x.Batch).Not.Nullable();
            Map(x => x.Postal_Code).Not.Nullable();

            References<Clients>(x => x.Client).Not.LazyLoad();

        }
    }
}
