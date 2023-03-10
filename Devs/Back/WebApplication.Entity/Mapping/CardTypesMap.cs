using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity.Mapping
{
    class CardTypesMap : SubclassMap<CardTypes>
    {
        public CardTypesMap()
        {
            Abstract();
            // Table("cards");  spécifier le nom de la table ici
            Map(x => x.CardType).Not.Nullable();
        }
    }
}

