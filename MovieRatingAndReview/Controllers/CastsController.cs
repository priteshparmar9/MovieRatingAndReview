using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRatingAndReview.Models;

namespace MovieRatingAndReview.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly UserContext _context;

        public CastsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Casts
        [HttpGet("/getallcasts")]
        public async Task<ActionResult<IEnumerable<Casts>>> GetCasts()
        {
            return await _context.Casts.ToListAsync();
        }

        // GET: api/Casts/5
        [HttpGet("/getcast/{id}")]
        public async Task<ActionResult<Casts>> GetCasts(int id)
        {
            var casts = await _context.Casts.FindAsync(id);

            if (casts == null)
            {
                return NotFound();
            }

            return casts;
        }

        // PUT: api/Casts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/updatecast/{id}")]
        public async Task<IActionResult> PutCasts(int id, Casts casts)
        {
            if (id != casts.Id)
            {
                return BadRequest();
            }

            _context.Entry(casts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CastsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Casts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/uploadcast")]
        public async Task<ActionResult<Casts>> PostCasts(Casts casts)
        {
            _context.Casts.Add(casts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasts", new { id = casts.Id }, casts);
        }

        // DELETE: api/Casts/5
        [HttpDelete("/deletecast/{id}")]
        public async Task<IActionResult> DeleteCasts(int id)
        {
            var casts = await _context.Casts.FindAsync(id);
            if (casts == null)
            {
                return NotFound();
            }

            _context.Casts.Remove(casts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CastsExists(int id)
        {
            return _context.Casts.Any(e => e.Id == id);
        }
    }
}
