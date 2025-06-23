using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTRA_Backend.Models;

namespace MTRA_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgreementController : ControllerBase
    {
        private readonly MtraDbContext _context;
        public AgreementController(MtraDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agreement>>> GetAgreement() => await _context.Agreement.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Agreement>> GetAgreement(int id)
        {
            var agr = await _context.Agreement.FindAsync(id);
            if (agr == null) return NotFound();
            return agr;
        }

        [HttpPost]
        public async Task<ActionResult<Agreement>> PostAgreement(Agreement agr)
        {
            _context.Agreement.Add(agr);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAgreement), new { id = agr.AgreementID }, agr);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgreement(int id, Agreement agr)
        {
            if (id != agr.AgreementID) return BadRequest();
            _context.Entry(agr).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgreement(int id)
        {
            var agr = await _context.Agreement.FindAsync(id);
            if (agr == null) return NotFound();
            _context.Agreement.Remove(agr);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
