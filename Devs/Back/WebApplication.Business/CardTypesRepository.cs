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
    public class CardTypesRepository : EntityRepository<CardTypes>
    {
        public CardTypes FindCardTypesByName(string Name)
        {
            using(ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                return session.Query<CardTypes>().Where(
                    x => x.CardType.ToString() == Name).FirstOrDefault();
            }
        }
    }
}
