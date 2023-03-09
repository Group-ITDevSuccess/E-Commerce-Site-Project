using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity.Mapping
{
    class CardsMap : SubclassMap<Cards>
    {
        public CardsMap()
        {
            Abstract();
            Map(x => x.CardType).CustomType<CardTypeEnum>();
            Map(x => x.Description).Not.Nullable();
        }
    }
}
