using Company.DAL.Contexts;
using Company.DAL.Reposatires.DepartmentRepo;
using Company.DAL.Reposatires.EmployeeRepo;

namespace Company.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IEmployeeRepository Employees { get; }
        public IDepartmentRepositries Departments { get; }

        public UnitOfWork(ApplicationDbContext context,
                          IEmployeeRepository employeeRepository,
                          IDepartmentRepositries departmentRepository)
        {
            _context = context;
            Employees = employeeRepository;
            Departments = departmentRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
