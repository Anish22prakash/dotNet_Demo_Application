using Microsoft.EntityFrameworkCore;
using System.Web;

namespace entityFrameWork.Model
{
    public class EmployeContext:DbContext
    {
        public EmployeContext(DbContextOptions options):base(options){ }

       public  DbSet<Employee> Employees { get; set; }

        


    }
}
