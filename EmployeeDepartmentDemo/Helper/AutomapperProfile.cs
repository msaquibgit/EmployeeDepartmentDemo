using AutoMapper;
using EmployeeDepartmentDemo.DTOs;
using EmployeeDepartmentDemo.Models;
using EmployeeDepartmentDemo.ModelVM;

namespace EmployeeDepartmentDemo.Helper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Employee, EmployeeVm>();
        }
    }
}
