using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class UsersMap : SubclassMap<Users>
    {
        public UsersMap()
        {
            Abstract();
            Map(x => x.FirstNameUser).Not.Nullable();
            Map(x => x.LastNameUser).Not.Nullable();
            Map(x => x.BirthDayUser).Not.Nullable();
            Map(x => x.GenreUser).Not.Nullable();
        }
    }
}
