using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class StocksMap : SubclassMap<Stocks>
    {
        public StocksMap()
        {
            Abstract();
            Map(x => x.Quantite).Not.Nullable();
            Map(x => x.Remarque).Nullable();

            HasManyToMany<Products>(x => x.Product)
                .Table("HistoriqueStock")
                .Cascade.All()
                .Inverse()
                .Not.LazyLoad();

        }
    }
}
