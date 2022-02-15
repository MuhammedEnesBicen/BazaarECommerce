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
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=bazaar; integrated security = true;");

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Card> Cards { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Electronic> Electronics { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CampaignImage> CampaignImages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Clothe> Clothes { get; set; }



        /*
         son migrationsu silmek için önce
        Update-Database refactorings(gitmek istediğimiz son migrations)
        ardından Remove-Migrations
         */
    }
}
