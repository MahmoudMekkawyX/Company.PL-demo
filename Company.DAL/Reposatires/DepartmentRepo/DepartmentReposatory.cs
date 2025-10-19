using Company.DAL.Contexts;
using Company.DAL.Models.Department;
using Company.DAL.Reposatires.GenericsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Reposatires.DepartmentRepo
{
    public class DepartmentReposatory : GenericRepository<Department>,IDepartmentRepositries
    {
        private readonly ApplicationDbContext _context;
        public DepartmentReposatory(ApplicationDbContext context) :base(context)
        {
            _context = context;
        
        }
       
    }
}
