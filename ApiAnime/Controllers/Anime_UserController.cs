using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAnime.Data;
using ApiAnime.Models;
using ApiAnime.Helpers;

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

        [HttpGet("{username}/{animename}")]
        public ActionResult<List<Anime_User>> GetAnime_UserbyName(string username, string animename)
        {
            var anime_User = _context.Anime_User.Where(usuario => usuario.Username.Equals(username) && usuario.AnimeName.Equals(animename)).ToList();

            if (anime_User == null)
            {
                return NotFound();
            }

            return anime_User;
        }

        // POST: api/Anime_User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Anime_User>> PostAnime_User(Anime_User anime_User)
        {
            _context.Anime_User.Add(anime_User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnime_User", new { id = anime_User.FavoritoId }, anime_User);
        }

        // DELETE: api/Anime_User/5
        [Authorize]
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
