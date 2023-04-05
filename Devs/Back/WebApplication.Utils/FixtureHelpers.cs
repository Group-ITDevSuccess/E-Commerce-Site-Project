using NHibernate;
using System;
using System.Threading.Tasks;
using WebApplication.Entity;
using WebApplication.Enum;

namespace WebApplication.Utils
{
    public class FixtureHelpers
    {
        public async Task AddFixturesCardType()
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.AmericanExpress,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.Mastercard,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.Visa,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.Discover,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.DinersClub,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.JCB,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.UnionPay,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.Maestro,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
                        {
                            CardType = CardTypeEnum.VisaElectron,
                        });

                        await session.SaveOrUpdateAsync(new CardTypes()
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

        public async Task AddFixturesRole()
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        await session.SaveOrUpdateAsync(new Role()
                        {
                            Nom = UserRoleEnum.ADMIN,
                        });
                        await session.SaveOrUpdateAsync(new Role()
                        {
                            Nom = UserRoleEnum.CLIENT,
                        });
                        await session.SaveOrUpdateAsync(new Role()
                        {
                            Nom = UserRoleEnum.USER,
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