using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Brand : IEntity
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public List<Product> Products { get; set; }
        public bool Status { get; set; }

    }
}
