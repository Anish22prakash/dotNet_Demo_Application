using Microsoft.EntityFrameworkCore;

namespace ShoppingApplication.DataBase
{
    public class MyDataBase :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("customer");
            optionsBuilder.UseInMemoryDatabase("order");
            optionsBuilder.UseInMemoryDatabase("orderDetails");
            optionsBuilder.UseInMemoryDatabase("payment");
            optionsBuilder.UseInMemoryDatabase("product");
            optionsBuilder.UseInMemoryDatabase("category");

        }

        public DbSet<>

    }
}
