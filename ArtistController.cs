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
}
