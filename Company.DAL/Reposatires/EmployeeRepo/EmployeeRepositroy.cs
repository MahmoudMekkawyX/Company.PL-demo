using Company.DAL.Contexts;
using Company.DAL.Models.Department;
using Company.DAL.Reposatires.GenericsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Reposatires.EmployeeRepo
{
    public class EmployeeRepositroy :GenericRepository<Employee> ,IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepositroy(ApplicationDbContext context) : base (context)
        {
            _context = context;

        }


    }
}
