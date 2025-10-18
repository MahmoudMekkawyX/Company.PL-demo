using AutoMapper;
using Company.DAL.Models.Department;
using ompany.BLL.Dto_s.Employee;

namespace ompany.BLL.Commen
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            // Employee → EmployeeDto
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.DepartmentName,
                           opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : "N/A"))
                .ReverseMap();

            // Employee → EmployeeDetailsDto
            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.DepartmentName,
                           opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : "N/A"))
                .ReverseMap();

            // CreateEmployeeDto → Employee
            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.EmployeeType,
                           opt => opt.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.Gender,
                           opt => opt.MapFrom(src => src.Gender));

            // UpdateEmployeeDto ↔ Employee
            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
        }
    }
}
