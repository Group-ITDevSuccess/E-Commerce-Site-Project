using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity.Services
{
    public class CardsReq
    {
        /*public CardsReq()
        {
            Number = GenerateCardNumber();
        }*/
        public string Number { get; set; } = GenerateCardNumber();
        public string PassWord { get; set; } 
        public DateTime DateCreation { get; set; } = DateTime.Now;
        /*public virtual CardTypes CardType { get; set; }
        public virtual Agence Agence { get; set; }*/
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
