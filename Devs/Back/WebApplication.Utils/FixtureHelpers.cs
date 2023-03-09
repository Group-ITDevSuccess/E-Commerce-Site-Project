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
                            Description = "American Express is a premium credit card with exclusive benefits such as airport lounge access and personal assistance."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.Mastercard,
                            Description = "Mastercard is an international credit card with a wide variety of reward programs."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.Visa,
                            Description = "Visa is an international credit card widely accepted worldwide."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.Discover,
                            Description = "Discover is a credit card with a strong cashback policy and an excellent rewards program."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.DinersClub,
                            Description = "Diners Club is a high-end credit card with exclusive benefits such as travel perks and concierge service."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.JCB,
                            Description = "JCB is a Japanese credit card widely accepted worldwide."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.UnionPay,
                            Description = "UnionPay is the primary credit card of China, accepted worldwide."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.Maestro,
                            Description = "Maestro is a popular international debit card, often associated with current accounts."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.VisaElectron,
                            Description = "Visa Electron is an international debit card with limited usage for certain types of transactions."
                        });

                        await session.SaveOrUpdateAsync(new Cards()
                        {
                            CardType = CardTypeEnum.PayPal,
                            Description = "PayPal is a popular online payment platform that allows users to make secure online payments."
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