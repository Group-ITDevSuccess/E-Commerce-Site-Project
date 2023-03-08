using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class CategoriesMap : SubclassMap<Categories>
    {
        public CategoriesMap()
        {
            Abstract();
            Map(x => x.Type).Not.Nullable();
            Map(x => x.Description).Not.Nullable();
        }
    }
}
