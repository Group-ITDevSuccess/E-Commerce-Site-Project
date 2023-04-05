using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Mapping
{
    class RoleMap : SubclassMap<Role>
    {
        public RoleMap()
        {
            Abstract();
            Map(x => x.Nom);
            Map(x => x.Description);
            HasManyToMany(x => x.User)
                .Cascade.All()
                .Inverse()
                .Table("UsersRoles");
        }
    }
}
