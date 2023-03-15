using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class CardsMap : SubclassMap<Cards>
    {
        public CardsMap()
        {
            Abstract();

            Map(x => x.Number)
                /*.Access.ReadOnly()
                .Generated.Insert()*/
                .Not.Nullable()
                /*.Unique()
                .Length(16);*/;

            Map(x => x.PassWord)
                .Not.Nullable()
               /* .Length(50);*/;

            Map(x => x.DateCreation)
                /*.Access.ReadOnly()
                .Generated.Insert()*/
                .Not.Nullable()
                /* .CustomType("datetime2")
                 .Column("CreationDate");*/;

            References(x => x.Agence)
                /*.Cascade.SaveUpdate()*/
                
                .Not.LazyLoad();
        }
    }
}
