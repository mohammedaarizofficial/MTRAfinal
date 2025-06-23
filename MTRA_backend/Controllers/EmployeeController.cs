using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTRA_Backend.Models;

namespace MTRA_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly MtraDbContext _context;
        public EmployeeController(MtraDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee() => await _context.Employee.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            var emp = await _context.Employee.FindAsync(id);
            if (emp == null) return NotFound();
            return emp;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee emp)
        {
            _context.Employee.Add(emp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployee), new { id = emp.EmpID }, emp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee emp)
        {
            if (id != emp.EmpID) return BadRequest();
            _context.Entry(emp).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var emp = await _context.Employee.FindAsync(id);
            if (emp == null) return NotFound();
            _context.Employee.Remove(emp);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
