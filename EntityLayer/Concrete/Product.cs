using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int? DiscountedPrice { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrl2 { get; set; }
        public int Stock { get; set; }
        
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        
        public int? BrandID { get; set; }
        public virtual Brand Brand { get; set; }

        public List<Order> Orders { get; set; }
        public List<Comment> Comments { get; set; }
        public List<BasketList> BasketLists { get; set; }
        public bool Status { get; set; }



    }
}
