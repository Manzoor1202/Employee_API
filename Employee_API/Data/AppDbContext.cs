using Shared_Library.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Employee_API.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
