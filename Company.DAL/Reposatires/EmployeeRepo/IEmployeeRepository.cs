using Company.DAL.Models.Department;
using Company.DAL.Reposatires.GenericsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Reposatires.EmployeeRepo
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
      // spacific signuture 
    }
}
