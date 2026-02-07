using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleDotNetSqlApi.Data;
using SimpleDotNetSqlApi.Models;

namespace SimpleDotNetSqlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: http://<ip>:5000/api/employees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _context.Employees.ToListAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }

        // POST: http://<ip>:5000/api/employees
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return Ok("Employee added successfully!");
            }
            catch (Exception ex)
            {
                // This will show SQL errors clearly
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
