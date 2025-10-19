using ompany.BLL.Dto_s.DepartmentDto_s;
using ompany.BLL.Dto_s.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ompany.BLL.services.EmployeeServices
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDetailsDto GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto dto);
        int UpdateEmployee(UpdateEmployeeDto dto);
        int DeleteEmployee(int id);
    }
}
