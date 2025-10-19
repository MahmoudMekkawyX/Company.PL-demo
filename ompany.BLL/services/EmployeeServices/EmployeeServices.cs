using AutoMapper;
using Company.DAL.Models.Department;
using Company.DAL.Reposatires.EmployeeRepo;
using Company.DAL.UOW;
using ompany.BLL.Dto_s.Employee;
using System;
using System.Collections.Generic;

namespace ompany.BLL.services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var employees = unitOfWork.Employees.GetAll();
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var employee = unitOfWork.Employees.GetById(id);
            return mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }

        public int CreateEmployee(CreateEmployeeDto dto)
        {
            var emp = mapper.Map<CreateEmployeeDto, Employee>(dto);
            emp.CreatedBy = 1;
            emp.createdOn = DateTime.Now;
            emp.LastModifiedBy = 1;
            emp.LastModifiedOn = DateTime.Now;

            unitOfWork.Employees.Add(emp);
            return unitOfWork.Complete();
        }

        public int UpdateEmployee(UpdateEmployeeDto dto)
        {
            var emp = mapper.Map<UpdateEmployeeDto, Employee>(dto);
            emp.LastModifiedBy = 1;
            emp.LastModifiedOn = DateTime.Now;

            unitOfWork.Employees.Update(emp);
            return unitOfWork.Complete();
        }

        public int DeleteEmployee(int id)
        {
            unitOfWork.Employees.Delete(id);
            return unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetSearchedEmployees(string? searchValue)
        {
            var employees = unitOfWork.Employees.GetAll(searchValue);
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        }
    }
}
