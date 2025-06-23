using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTRA_Backend.Models;

namespace MTRA_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly MtraDbContext _context;
        public MaterialController(MtraDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterial() => await _context.Material.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var mat = await _context.Material.FindAsync(id);
            if (mat == null) return NotFound();
            return mat;
        }

        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material mat)
        {
            _context.Material.Add(mat);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMaterial), new { id = mat.MaterialID }, mat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material mat)
        {
            if (id != mat.MaterialID) return BadRequest();
            _context.Entry(mat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var mat = await _context.Material.FindAsync(id);
            if (mat == null) return NotFound();
            _context.Material.Remove(mat);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
