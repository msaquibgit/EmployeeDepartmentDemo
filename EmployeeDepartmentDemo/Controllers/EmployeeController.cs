using AutoMapper;
using EmployeeDepartmentDemo.DataContext;
using EmployeeDepartmentDemo.DTOs;
using EmployeeDepartmentDemo.Models;
using EmployeeDepartmentDemo.ModelVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentDemo.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;
        public EmployeeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employee = (from E in _context.Employees
                            join D in _context.Departments
                           on E.DepartmentId equals D.Id
                            select new EmployeeVm
                            {
                                FirstName = E.FirstName,
                                Lastname = E.Lastname,
                                Email = E.Email,
                                Department=D.Name,
                                Location=D.Location
                            }).ToList();
            if (employee.Count > 0)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDTO dto)
        {
            if (dto == null) return default;
            var model = _mapper.Map<Employee>(dto);
            _context.Employees.Add(model);
            int i = _context.SaveChanges();
            if (i > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}


    

