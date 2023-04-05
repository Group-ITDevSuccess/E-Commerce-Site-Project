using Newtonsoft.Json;
using System;
using WebApplication.Enum;

namespace WebApplication.Entity
{
    public class Cards : Entity
    {
        public virtual string Number { get; set; }
        public virtual string PassWord { get; set; }
        public virtual DateTime DateCreation { get; set; }
        public virtual Agence Agence { get; set; }
        public virtual CardTypes CardType { get; set; }
        
    }
}
