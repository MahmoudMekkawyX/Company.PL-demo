using Company.DAL.Models.Department;
using Company.DAL.Models.shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e=>e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,3)");
            builder.Property(e => e.Gender)
                  .HasConversion(
                       empGender => empGender.ToString(),
                        (Gender) => (Gender)Enum.Parse(typeof(Gender), Gender)
                   );
            builder.Property(e => e.EmployeeType)
                 .HasConversion(
                      Etype => Etype.ToString(),
                      (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType),type)
                  );



        }
    }
}
