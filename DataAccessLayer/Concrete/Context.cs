using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             //Uzak Bağlantı
             optionsBuilder.UseSqlServer("Data Source=ecommercecasgem.database.windows.net;initial catalog=ECommerceDataBase; User ID=admindb;Password=Ab12cd34.;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //Locale
            //optionsBuilder.UseSqlServer("Data Source=FRKN\\SQLEXPRESS;initial catalog=ECommerceDataBase; integrated Security=true");
        }

        public DbSet<Admin> Admins { get; set; }       
        public DbSet<BasketList> BasketLists { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
