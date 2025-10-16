using Company.DAL.Models.Department;
using Company.DAL.Reposatires.GenericsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Reposatires.DepartmentRepo
{
    public interface IDepartmentRepositries:IGenericRepository<Department>
    {
       
    }
}
