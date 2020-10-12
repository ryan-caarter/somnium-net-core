using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using somniumAPI.Models;

namespace somniumAPI.Controllers
{
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistContext _context;

        public ArtistController(ArtistContext context)
        {
            _context = context;
        }

        // GET: api/Artist
        [HttpGet]
        [Route("/")]
        public async Task<ActionResult<IEnumerable<Artists>>> GetArtists()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artists>> GetArtists(long id)
        {
            var artists = await _context.TodoItems.FindAsync(id);

            if (artists == null)
            {
                return NotFound();
            }

            return artists;
        }

        // PUT: api/Artist/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtists(long id, Artists artists)
        {
            if (id != artists.id)
            {
                return BadRequest();
            }

            _context.Entry(artists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistsExists(id))
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

        // POST: api/Artist
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artists>> PostArtists(Artists artists)
        {
            _context.TodoItems.Add(artists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtists", new { id = artists.id }, artists);
        }

        // DELETE: api/Artist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artists>> DeleteArtists(long id)
        {
            var artists = await _context.TodoItems.FindAsync(id);
            if (artists == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(artists);
            await _context.SaveChangesAsync();

            return artists;
        }

        private bool ArtistsExists(long id)
        {
            return _context.TodoItems.Any(e => e.id == id);
        }
    }
}
