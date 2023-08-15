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
    public class BasketListManager : IBasketListService
    {
        private readonly IBasketListDal _basketListDal;

        public BasketListManager(IBasketListDal basketListDal)
        {
            _basketListDal = basketListDal;
        }

        public bool TBasketControl(int id, int userid)
        {
           return _basketListDal.BasketControl(id,userid);
        }

        public int TBasketSumPrice(int userid)
        {
            return _basketListDal.BasketSumPrice(userid);
        }

        public bool TCardNumberControl(string cardNumber)
        {
            return _basketListDal.CardNumberControl(cardNumber);
        }

        public void TDelete(BasketList t)
        {
            _basketListDal.Delete(t);
        }

        public void TDeleteBasket(int basketid)
        {
            _basketListDal.DeleteBasket(basketid);
        }

        public void TDeleteBaskets(int userid)
        {
            _basketListDal.DeleteBaskets(userid);
        }

        public List<BasketList> TGetBasketWithProduct(int userid)
        {
            return _basketListDal.GetBasketWithProduct(userid);
        }

        public BasketList TGetByID(int id)
        {
            return _basketListDal.GetByID(id);
        }

        public List<BasketList> TGetList()
        {
            return _basketListDal.GetList();
        }

        public void TInsert(BasketList t)
        {
            _basketListDal.Insert(t);
        }

        public void TUpdate(BasketList t)
        {
            _basketListDal.Update(t);
        }

        public void TUpdateCount(int basketid, int count)
        {
            _basketListDal.UpdateCount(basketid, count);
        }
    }
}
