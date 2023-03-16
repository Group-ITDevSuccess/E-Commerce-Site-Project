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
                .Not.Nullable()
                .Unique()
                .Length(16);

            Map(x => x.PassWord)
                .Not.Nullable()
                .Length(4);

            Map(x => x.DateCreation)
                .Not.Nullable();

            References(x => x.Agence)
                /*.Cascade.SaveUpdate()*/
                .Not.LazyLoad();

            References(x => x.CardType)
                .Cascade.SaveUpdate()
                .Not.LazyLoad();
        }
    }
}
