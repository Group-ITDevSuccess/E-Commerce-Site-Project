﻿using FluentNHibernate.Mapping;
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
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Pseudo).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.PassWord).Not.Nullable();

            HasMany(x => x.Info)
                .Inverse()
                .Cascade.All()
                .Not.LazyLoad();
        }
    }
}