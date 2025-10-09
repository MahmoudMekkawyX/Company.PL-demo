using Company.DAL.Models.Department;


namespace Company.DAL.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            // createdOn ياخد تاريخ الإنشاء مرة واحدة
            builder.Property(d => d.createdOn)
                   .HasDefaultValueSql("GETDATE()");

            // LastModifiedOn يتولد/يتحدث عند كل Update
            builder.Property(d => d.LastModifiedOn)
                   .ValueGeneratedOnAddOrUpdate()
                   .HasComputedColumnSql("GETDATE()", stored: false);




        }
    }
}
