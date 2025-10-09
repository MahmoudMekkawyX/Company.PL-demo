using Company.DAL.Models.Department;
using Company.DAL.Reposatires.DepartmentRepo;
using ompany.BLL.Dto_s.DepartmentDto_s;
using ompany.BLL.Factories.DepartmentFactories;
using ompany.BLL.services;


namespace Company.BLL.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepositries _reposatory;

        public DepartmentServices(IDepartmentRepositries reposatory)
        {
            _reposatory = reposatory;
        }

        public IEnumerable<DepartmentDto> GetDepartments()
        {
            var departments = _reposatory.GetAll();

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
            var department = _reposatory.GetById(id);

            if (department is null) return null;

            var departmentToReturn = department.ToEntity();
            return departmentToReturn;
        }

        public int AddDepartment(CreateDepartmentDto dto)
        {
            var dept = dto.toDepartment();
            return _reposatory.Add(dept);
        }

        public int UpdateDepartment(UpdatedDepoartmentDto dto)
        {
            var dept = dto.FromUpdatedDepartment();
            return _reposatory.Update(dept);
        }

        public int DeleteDepartment(int id)
        {
            return _reposatory.Delete(id);
        }
    }
}

