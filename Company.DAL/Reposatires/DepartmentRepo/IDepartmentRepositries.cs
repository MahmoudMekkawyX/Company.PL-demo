using Company.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Reposatires.DepartmentRepo
{
    public interface IDepartmentRepositries
    {
        public IEnumerable<Department> GetAll(bool withTrqacking = false);
        public Department GetById(int id);
        public int Add (Department department);
        public int Update (Department department);
        public int Delete (int id);
    }
}
