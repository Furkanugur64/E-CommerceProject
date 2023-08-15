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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public List<Order> GetOrderByUser(int id)
        {
            using var context = new Context();
            var result = context.Orders.Include("Product").Where(x => x.UserID == id).ToList();
            return result;
        }
    }
}
