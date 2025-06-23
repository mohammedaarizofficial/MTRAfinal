using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTRA_Backend.Models;

namespace MTRA_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly MtraDbContext _context;
        public DeliveryController(MtraDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDelivery() => await _context.Delivery.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDelivery(int id)
        {
            var del = await _context.Delivery.FindAsync(id);
            if (del == null) return NotFound();
            return del;
        }

        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(Delivery del)
        {
            _context.Delivery.Add(del);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDelivery), new { id = del.DeliveryID }, del);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, Delivery del)
        {
            if (id != del.DeliveryID) return BadRequest();
            _context.Entry(del).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var del = await _context.Delivery.FindAsync(id);
            if (del == null) return NotFound();
            _context.Delivery.Remove(del);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
