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
                .Column("BrandId")
                .Cascade.All()
                .Not.LazyLoad();

            References(x => x.CategorieProduct)
                .Column("CategorieId")
                .Cascade.All()
                .Not.LazyLoad();

            HasMany(x => x.Stock)
                .Inverse()
                .Cascade.All()
                .Not.LazyLoad();
        }
    }
}
