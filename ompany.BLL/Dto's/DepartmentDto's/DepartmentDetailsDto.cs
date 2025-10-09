using Company.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ompany.BLL.Dto_s.DepartmentDto_s
{
    public class DepartmentDetailsDto
    {
        public DepartmentDetailsDto(Department Department)
        {
            Id = Department.Id;
            Name = Department.Name;
            Code = Department.Code;
            Description = Department.Description;
            createdOn = Department.createdOn;  // لو الخاصية DateTime
            CreatedBy = Department.CreatedBy;
            LastModifiedOn = Department.LastModifiedOn;  // لو الخاصية DateTime
            LastModifiedBy = Department.LastModifiedBy;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime createdOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
