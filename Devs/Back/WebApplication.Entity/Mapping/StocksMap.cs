﻿using FluentNHibernate.Mapping;
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
            
            References(x => x.Product)
            .Column("ProductId")
            .Cascade.None()
            .Not.LazyLoad();
        }
    }
}
