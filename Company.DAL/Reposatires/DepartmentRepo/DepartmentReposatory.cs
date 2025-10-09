using Company.DAL.Contexts;
using Company.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Reposatires.DepartmentRepo
{
    public class DepartmentReposatory : IDepartmentRepositries
    {
        private readonly ApplicationDbContext _context;
        public DepartmentReposatory(ApplicationDbContext context)
        {
            _context = context;
        
        }
        public IEnumerable<Department> GetAll(bool withTrqacking=false)
        {
           if(withTrqacking) 
                return _context.Departments.ToList();
           else
                return _context.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            var Department = _context.Departments.Find(id);
            return Department;
        }
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }

        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var Department = _context.Departments.Find(id);
            _context.Departments.Remove(Department);
            return _context.SaveChanges();
        }

    }
}
