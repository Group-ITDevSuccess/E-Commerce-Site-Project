using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class Contacts : Entity
    {
        public Contacts()
        {
            DateCreation = DateTime.Now;
        }
        public virtual string Phone { get; set; }
        public virtual DateTime DateCreation { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }
    }
}
