﻿using Core.Business.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICouponService : IGenericService<Coupon>
    {
        public string TCheckCoupon(string couponCode);
    }
}
