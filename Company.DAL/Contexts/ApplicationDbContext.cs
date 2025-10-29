using Company.DAL.Models;
using Company.DAL.Models.Department;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Company.DAL.Contexts
{
    public class ApplicationDbContext :IdentityDbContext<ApplicatiionUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder) : base(optionsBuilder)
        {

        
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
