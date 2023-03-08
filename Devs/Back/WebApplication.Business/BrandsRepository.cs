using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entity;

namespace WebApplication.Business
{
    public class BrandsRepository : EntityRepository<Brand>
    {
        public string FindBrandName(string Name)
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                var result = session.Query<Brand>().Where(x => x.BrandName == Name).ToString();
                return result;
            }
        }
    }
}
