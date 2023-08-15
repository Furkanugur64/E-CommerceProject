using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CouponManager : ICouponService
    {
        private readonly ICouponDal _couponDal;

        public CouponManager(ICouponDal couponDal)
        {
            _couponDal = couponDal;
        }

        public string TCheckCoupon(string couponCode)
        {
            return _couponDal.CheckCoupon(couponCode);
        }

        public void TDelete(Coupon t)
        {
            _couponDal.Delete(t);
        }

        public Coupon TGetByID(int id)
        {
            return _couponDal.GetByID(id);
        }

        public List<Coupon> TGetList()
        {
            return _couponDal.GetList();
        }

        public void TInsert(Coupon t)
        {
            _couponDal.Insert(t);
        }

        public void TUpdate(Coupon t)
        {
            _couponDal.Update(t);
        }
    }
}
