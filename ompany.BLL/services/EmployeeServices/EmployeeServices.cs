using AutoMapper;
using Company.DAL.Models.Department;
using Company.DAL.Reposatires.EmployeeRepo;
using ompany.BLL.Dto_s.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ompany.BLL.services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository emplyeeRepository;
        private readonly IMapper mapper;

        public EmployeeServices(IEmployeeRepository employeeRepository , IMapper mapper) 
        {
            this.emplyeeRepository = employeeRepository;
            this.mapper = mapper;
        
        }
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var Employees = emplyeeRepository.GetAll();
            var MappedEmployees = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Employees);
            return MappedEmployees;
        }
        public EmployeeDetailsDto GetEmployeeById(int id)
        {
           var Employee = emplyeeRepository.GetById(id);
            var MappedEmployee = mapper.Map<Employee, EmployeeDetailsDto>(Employee);
            return MappedEmployee;
        }

        public int CreateEmployee(CreateEmployeeDto dto)
        {
            var Emp = mapper.Map<CreateEmployeeDto, Employee>(dto);
            Emp.CreatedBy = 1;
            Emp.createdOn = DateTime.Now;
            Emp.LastModifiedBy = 1;
            Emp.LastModifiedOn= DateTime.Now;

            return emplyeeRepository.Add(Emp);

        }

        public int UpdateEmployee(UpdateEmployeeDto dto)
        {
            var Emp = mapper.Map<UpdateEmployeeDto, Employee>(dto);
            Emp.LastModifiedBy = 1;
            Emp.LastModifiedOn = DateTime.Now;
            return emplyeeRepository.Update(Emp);

        }
        public int DeleteEmployee(int id)
        {
            return emplyeeRepository.Delete(id);
        }

      

      
    }
}
