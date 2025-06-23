using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTRA_Backend.Models;

namespace MTRA_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountingController : ControllerBase
    {
        private readonly MtraDbContext _context;
        public AccountingController(MtraDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accounting>>> GetAccounting() => await _context.Accounting.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Accounting>> GetAccounting(int id)
        {
            var acc = await _context.Accounting.FindAsync(id);
            if (acc == null) return NotFound();
            return acc;
        }

        [HttpPost]
        public async Task<ActionResult<Accounting>> PostAccounting(Accounting acc)
        {
            _context.Accounting.Add(acc);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccounting), new { id = acc.AccountID }, acc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccounting(int id, Accounting acc)
        {
            if (id != acc.AccountID) return BadRequest();
            _context.Entry(acc).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccounting(int id)
        {
            var acc = await _context.Accounting.FindAsync(id);
            if (acc == null) return NotFound();
            _context.Accounting.Remove(acc);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
