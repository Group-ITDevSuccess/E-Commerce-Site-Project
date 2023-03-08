using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entity
{
    public class Products : Entity
    {
        public virtual string ProductName { get; set; }
        public virtual string ProductPrice { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual Brand BrandProduct { get; set; }
        public virtual Categories CategorieProduct { get; set; }
        public virtual IList<Stocks> Stock { get; set; }
    }
}
