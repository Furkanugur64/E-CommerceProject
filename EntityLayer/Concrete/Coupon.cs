using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Coupon : IEntity
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public DateTime Date { get; set; }

    }
}
