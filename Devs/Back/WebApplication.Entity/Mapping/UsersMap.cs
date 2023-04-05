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
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Pseudo).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.PassWord).Not.Nullable();
            HasManyToMany(x => x.Roles)
                .Not.LazyLoad()
                .Table("UsersRoles");

            HasMany(x => x.Info)
                .Inverse()
                .Cascade.All()
                .Not.LazyLoad();

            Map(x => x.BirthDay).Not.Nullable();
            Map(x => x.Genre).Not.Nullable();

            References(x => x.Address)
                .Column("AddressId")
                .Cascade.All()
                .Not.LazyLoad();

            References(x => x.Account)
                .Column("AccountId")
                .Cascade.All()
                .Not.LazyLoad();

            References(x => x.Card)
                .Column("CardId")
                .Cascade.SaveUpdate()
                .Not.LazyLoad();

            HasMany(x => x.Contact)
                /*.Inverse()*/
                .Cascade.All()
                .Not.LazyLoad();
        }
    }
}
