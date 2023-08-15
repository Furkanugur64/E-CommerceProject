using Core.DataAccess.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var context = new Context();
            context.Remove(t);
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var context = new Context();
            var dbSet = context.Set<T>();
            var allData = dbSet.ToList();
            //bu satırda eğer status property'si varsa true olanları getirmesini sağladık
            var statusProperty = typeof(T).GetProperty("Status");
            if (statusProperty != null && statusProperty.PropertyType == typeof(bool))
            {
                return allData.Where(item => (bool)statusProperty.GetValue(item)).ToList();
            }
            return allData;
        }

        public void Insert(T t)
        {
            using var context = new Context();
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new Context();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
