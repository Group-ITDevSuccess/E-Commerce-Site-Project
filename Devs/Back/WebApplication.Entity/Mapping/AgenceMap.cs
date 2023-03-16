using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class AgenceMap : SubclassMap<Agence>
    {
        public AgenceMap()
        {
            Abstract();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Denomination).Not.Nullable();
            HasMany(x => x.Cards)
                /*.Inverse()*/
                .Cascade.All()
                .Not.LazyLoad();
        }
    }
}
