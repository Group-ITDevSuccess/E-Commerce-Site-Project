using System;

namespace WebApplication.Entity
{
    public class Cards : Entity
    {
        public Cards()
        {
            Number = GenerateCardNumber();
            DateCreation = DateTime.Now;
        }

        public virtual string Number { get; set; }
        public virtual string PassWord { get; set; }
        public virtual DateTime DateCreation { get; set; }

        private static string GenerateCardNumber()
        {
            // Génère un numéro de carte bancaire unique
            Random random = new Random();
            string prefix = "55"; // Le préfixe "55" est réservé aux cartes bancaires
            string suffix = "";
            for (int i = 0; i < 14; i++)
            {
                suffix += random.Next(0, 10).ToString();
            }
            string cardNumber = prefix + suffix;
            return cardNumber;
        }
    }
}
