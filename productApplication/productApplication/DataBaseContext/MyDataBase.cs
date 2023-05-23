using Microsoft.EntityFrameworkCore;
using productApplication.ModelData;

namespace productApplication.DataBaseContext
{
    public class MyDataBase : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "productDataBase");
        }

        public DbSet<Product> Products { get; set; }

         
    }
}
