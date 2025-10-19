using Company.DAL.Reposatires.DepartmentRepo;
using Company.DAL.Reposatires.EmployeeRepo;

namespace Company.DAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepositries Departments { get; }

        int Complete();
    }
}
