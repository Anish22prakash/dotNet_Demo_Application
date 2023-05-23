using Microsoft.EntityFrameworkCore;
using Product_Category.Model;

namespace Product_Category.DataBaseContext
{
    public class MyDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "product");
            optionsBuilder.UseInMemoryDatabase(databaseName: "categories");
            optionsBuilder.UseInMemoryDatabase(databaseName: "customer");
            optionsBuilder.UseInMemoryDatabase(databaseName: "orders");
            optionsBuilder.UseInMemoryDatabase(databaseName: "payment");
            optionsBuilder.UseInMemoryDatabase(databaseName: "wishlist");
            optionsBuilder.UseInMemoryDatabase(databaseName: "cart");
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Products> products { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Orders> orders { get; set; }

        public DbSet<Payment> payments { get; set; }    

        public DbSet<WishList> wishList { get; set; }

        public DbSet<Cart> cart { get; set; }   


    }
}
