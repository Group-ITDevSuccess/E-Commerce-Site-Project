using NHibernate;
using System;
using System.Threading.Tasks;
using WebApplication.Entity;
using WebApplication.Enum;

namespace WebApplication.Utils
{
    public class FixtureHelpers
    {
        public async Task AddFixtures()
        {
            using(ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.AmericanExpress,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.Mastercard,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.Visa,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.Discover,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.DinersClub,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.JCB,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.UnionPay,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.Maestro,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.VisaElectron,
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.PayPal,
                        });

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }
            }

        }
    }
}