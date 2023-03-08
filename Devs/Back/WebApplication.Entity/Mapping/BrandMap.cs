using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class BrandMap : SubclassMap<Brand>
    {
        public BrandMap()
        {
            Abstract();
            Map(x => x.BrandName).Not.Nullable();
        }
    }
}
