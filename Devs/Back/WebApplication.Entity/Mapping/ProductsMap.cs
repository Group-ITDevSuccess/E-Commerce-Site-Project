using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class ProductsMap : SubclassMap<Products>
    {
        public ProductsMap()
        {
            Abstract();
            Map(x => x.ProductName).Not.Nullable();
            Map(x => x.ProductPrice).Not.Nullable();
            Map(x => x.ProductDescription).Nullable();


            References(x => x.BrandProduct)
                .Cascade.All()
                .Not.LazyLoad();

            References(x => x.CategorieProduct)
                .Cascade.All()
                .Not.LazyLoad();

            HasManyToMany<Stocks>(x => x.Stock)
                .Table("HistoriqueStock")
                .Not.LazyLoad();
        }
    }
}
