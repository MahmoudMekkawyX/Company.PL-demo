using ompany.BLL.Dto_s.DepartmentDto_s;
using Company.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ompany.BLL.Factories.DepartmentFactories
{
    public static class DepartmentFact
    {
        public static DepartmentDto ToDepartmentDto(this Department d)
        {
            return new DepartmentDto()
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description
            };
        }

        public static DepartmentDetailsDto ToEntity(this Department d)
        {
            return new DepartmentDetailsDto(d);
        }
        public static Department toDepartment(this CreateDepartmentDto dbo)
        {
            return new Department()
            {
                Name = dbo.Name,
                Code = dbo.Code,
                Description = dbo.Description,
                CreatedBy = 1,
                LastModifiedBy = 1,
                createdOn = DateTime.Now,
                LastModifiedOn = DateTime.Now,
                IsDeleted = false

            };
        }
        public static Department FromUpdatedDepartment(this UpdatedDepoartmentDto dbo)
        {
            return new Department()
            {
                Id = dbo.Id,
                Name = dbo.Name,
                Code = dbo.Code,
                Description = dbo.Description,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                IsDeleted = false

            };
        }

    }
}
