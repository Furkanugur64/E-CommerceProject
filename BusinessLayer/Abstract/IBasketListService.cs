using Core.Business.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBasketListService : IGenericService<BasketList>
    {
        bool TBasketControl(int id,int userid);
        public List<BasketList> TGetBasketWithProduct(int userid);
        public int TBasketSumPrice(int userid);
        void TUpdateCount(int basketid, int count);
        void TDeleteBasket(int basketid);
        public bool TCardNumberControl(string cardNumber);
        void TDeleteBaskets(int userid);
    }
}
