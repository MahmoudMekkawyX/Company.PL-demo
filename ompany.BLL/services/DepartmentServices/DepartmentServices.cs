using Company.DAL.Models.Department;
using Company.DAL.Reposatires.DepartmentRepo;
using Company.DAL.UOW;
using ompany.BLL.Dto_s.DepartmentDto_s;
using ompany.BLL.Factories.DepartmentFactories;


namespace ompany.BLL.services.DepartmentServices
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DepartmentDto> GetDepartments()
        {
            var departments = _unitOfWork.Departments.GetAll();

            var mappedDepartments = new List<DepartmentDto>();
            foreach (var dept in departments)
            {
                var mappedDepart = dept.ToDepartmentDto();
                mappedDepartments.Add(mappedDepart);
            }

            return mappedDepartments;
        }

        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);

            if (department is null) return null;

            var departmentToReturn = department.ToEntity();
            return departmentToReturn;
        }

        public int AddDepartment(CreateDepartmentDto dto)
        {
            var dept = dto.toDepartment();
            _unitOfWork.Departments.Add(dept);
            return _unitOfWork.Complete();
        }

        public int UpdateDepartment(UpdatedDepoartmentDto dto)
        {
            var dept = dto.FromUpdatedDepartment();
            _unitOfWork.Departments.Update(dept);
            return _unitOfWork.Complete();
        }

        public int DeleteDepartment(int id)
        {
             _unitOfWork.Departments.Delete(id);
            return _unitOfWork.Complete();
        }
    }
}

