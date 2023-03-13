using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    class CardTypesMap : SubclassMap<CardTypes>
    {
        public CardTypesMap()
        {
            Abstract();
            Map(x => x.CardType).Not.Nullable();
        }
    }
}
