using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTRA_Backend.Models;

namespace MTRA_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly MtraDbContext _context;

        public RequestController(MtraDbContext context)
        {
            _context = context;
        }

        // GET: api/request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            return await _context.Request.ToListAsync();
        }

        // GET: api/request/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(string id)
        {
            var request = await _context.Request.FindAsync(id);
            if (request == null)
                return NotFound();
            return request;
        }

        // POST: api/request
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Request.Add(request);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRequest), new { id = request.RequestID }, request);
        }

        // PUT: api/request/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(string id, Request request)
        {
            if (id != request.RequestID)
                return BadRequest();

            _context.Entry(request).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Request.Any(e => e.RequestID == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/request/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(string id)
        {
            var request = await _context.Request.FindAsync(id);
            if (request == null)
                return NotFound();

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
