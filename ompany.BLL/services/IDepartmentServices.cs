using ompany.BLL.Dto_s.DepartmentDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ompany.BLL.services
{
    public interface IDepartmentServices
    {
        IEnumerable<DepartmentDto> GetDepartments();
        DepartmentDetailsDto GetDepartmentById(int id);
        int AddDepartment(CreateDepartmentDto dto);
        int UpdateDepartment(UpdatedDepoartmentDto dto);
        int DeleteDepartment(int id);
    }
}
