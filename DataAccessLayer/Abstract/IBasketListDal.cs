using Core.DataAccess.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBasketListDal : IGenericDal<BasketList>
    {
        public bool BasketControl(int id,int userid);
        public List<BasketList> GetBasketWithProduct(int userid);
        public int BasketSumPrice(int userid);
        void UpdateCount(int basketid,int count);
        void DeleteBasket(int basketid);
        public bool CardNumberControl(string cardNumber);
        void DeleteBaskets(int userid);
    }
}
