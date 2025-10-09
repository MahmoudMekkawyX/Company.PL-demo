using Company.DAL.Models.Department;

namespace Company.DAL.Contexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder) : base(optionsBuilder)
        {

        
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Department> Departments { get; set; }
    }
}
