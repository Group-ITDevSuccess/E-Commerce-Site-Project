using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class Categories : Entity
    {
        public virtual string Type { get; set; }
        public virtual string Description { get; set; }
    }
}
