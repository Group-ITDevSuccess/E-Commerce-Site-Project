using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entity;
using WebApplication.Enum;

namespace WebApplication.Business
{
    public class RolesRepository : EntityRepository<Role>
    {
        public Role FindRolesByName(string Name)
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                return session.Query<Role>().Where(
                    x => x.Nom.ToString() == Name).FirstOrDefault();
            }
        }
    }
}

