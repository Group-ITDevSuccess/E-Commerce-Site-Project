using Newtonsoft.Json;
using System;
using WebApplication.Enum;

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
        public virtual Agence Agence { get; set; }
        public virtual CardTypes CardType { get; set; }
        private static string GenerateCardNumber()
        {
            Random random = new Random();
            string prefix = "55";
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
