using Company.DAL.Models.Department;


namespace Company.DAL.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            // createdOn ياخد تاريخ الإنشاء مرة واحدة
            

            // LastModifiedOn يتولد/يتحدث عند كل Update
            

            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);



        }
    }
}
