using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAnime.Data;
using ApiAnime.Models;

namespace ApiAnime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Anime_UserController : ControllerBase
    {
        private readonly ApiAnimeContext _context;

        public Anime_UserController(ApiAnimeContext context)
        {
            _context = context;
        }

        // GET: api/Anime_User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime_User>>> GetAnime_User()
        {
            return await _context.Anime_User.ToListAsync();
        }

        // GET: api/Anime_User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anime_User>> GetAnime_User(int id)
        {
            var anime_User = await _context.Anime_User.FindAsync(id);

            if (anime_User == null)
            {
                return NotFound();
            }

            return anime_User;
        }

        // PUT: api/Anime_User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnime_User(int id, Anime_User anime_User)
        {
            if (id != anime_User.FavoritoId)
            {
                return BadRequest();
            }

            _context.Entry(anime_User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Anime_UserExists(id))
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

        // POST: api/Anime_User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anime_User>> PostAnime_User(Anime_User anime_User)
        {
            _context.Anime_User.Add(anime_User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnime_User", new { id = anime_User.FavoritoId }, anime_User);
        }

        // DELETE: api/Anime_User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime_User(int id)
        {
            var anime_User = await _context.Anime_User.FindAsync(id);
            if (anime_User == null)
            {
                return NotFound();
            }

            _context.Anime_User.Remove(anime_User);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Anime_UserExists(int id)
        {
            return _context.Anime_User.Any(e => e.FavoritoId == id);
        }
    }
}
