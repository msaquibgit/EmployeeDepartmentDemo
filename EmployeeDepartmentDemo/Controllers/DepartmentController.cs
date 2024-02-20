using EmployeeDepartmentDemo.DataContext;
using EmployeeDepartmentDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Timers;

namespace EmployeeDepartmentDemo.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context ) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var department = _context.Departments.ToList();
            if (department.Count>0)
            {
                return Ok(department);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Department model)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(model);
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
            else
            {
                return BadRequest();
            }
        }
      
    }
}
