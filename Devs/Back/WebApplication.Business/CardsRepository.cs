using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entity;

namespace WebApplication.Business
{
    public class CardsRepository : EntityRepository<Cards>
    {
        public List<Cards> GetByAgenceId(Guid agenceId)
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                var cards = session.Query<Cards>().Where(x => x.Agence.Id == agenceId).ToList();
                return cards;
            }
        }
    }
}
