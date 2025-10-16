using AutoMapper;
using Company.DAL.Models.Department;
using ompany.BLL.Dto_s.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ompany.BLL.Commen
{
    public class ProjectMapperProfile:Profile
    {
        public ProjectMapperProfile() 
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap <Employee, EmployeeDetailsDto>().ReverseMap();

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                 .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender));

            CreateMap<UpdateEmployeeDto , Employee>().ReverseMap();
        }
    }
}
