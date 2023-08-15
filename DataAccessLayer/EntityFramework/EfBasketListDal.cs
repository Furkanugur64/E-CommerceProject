using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBasketListDal : GenericRepository<BasketList>, IBasketListDal
    {
        public bool BasketControl(int id,int userid)
        {
            using var context = new Context();
            var result = context.BasketLists.Where(x => x.ProductID == id && x.UserID==userid);

            if (result.Any())
            {
                // Eğer tabloda ürün varsa false değeri dönecek
                return false;
            }            
            return true;
        }

        public int BasketSumPrice(int userid)
        {
            using var context = new Context();
            var total = context.BasketLists.Where(x=>x.UserID==userid)
                .Sum(x => (x.Product.DiscountedPrice != null ? x.Product.DiscountedPrice.Value : x.Product.Price) * x.ProductCount);
            return total;
        }

        public bool CardNumberControl(string CardNumber)
        {
            string cardNumber = CardNumber.Replace("-", "");
            if (!long.TryParse(cardNumber, out long cardNumberNumeric))
                return false;

            if (cardNumber.Length < 13 || cardNumber.Length > 19)
                return false;

            int[] digits = cardNumber.ToCharArray()
                                      .Reverse()
                                      .Select(c => int.Parse(c.ToString()))
                                      .ToArray();

            int checksum = digits[0];
            digits = digits.Skip(1).ToArray();

            for (int i = 0; i < digits.Length; i++)
            {
                if (i % 2 == 0)
                {
                    digits[i] *= 2;
                    if (digits[i] > 9)
                    {
                        digits[i] -= 9;
                    }
                }
            }

            int total = digits.Sum() + checksum;

            return total % 10 == 0;
        }

        public void DeleteBasket(int basketid)
        {
            using var context = new Context();
            var result = context.BasketLists.Find(basketid);
            context.Remove(result);
            context.SaveChanges();
        }

        public void DeleteBaskets(int userid)
        {
            using var context = new Context();
            var result = context.BasketLists.Where(x => x.UserID == userid).ToList();
            foreach(var item in result)
            {
                context.Remove(item);
            }
            context.SaveChanges();
        }

        public List<BasketList> GetBasketWithProduct(int userid)
        {
            using var context = new Context();
            var result = context.BasketLists.Include("Product").Where(x=>x.UserID== userid).ToList();
            return result;
        }

        public void UpdateCount(int basketid, int count)
        {
            using var context = new Context();
            var basket=context.BasketLists.Find(basketid);
            basket.ProductCount= count;
            context.SaveChanges();
        }
    }
}
