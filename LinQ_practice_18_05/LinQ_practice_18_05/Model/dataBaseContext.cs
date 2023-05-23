using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinQ_practice_18_05.Model
{
    public class dataBaseContext:IdentityDbContext<ApplicationUser>
    {
        public dataBaseContext(DbContextOptions<dataBaseContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
