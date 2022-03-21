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
    public class AnimeDatasController : ControllerBase
    {
        private readonly ApiAnimeContext _context;

        public AnimeDatasController(ApiAnimeContext context)
        {
            _context = context;
        }

        // GET: api/AnimeDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeData>>> GetAnimeData()
        {
            return await _context.AnimeData.ToListAsync();
        }

        // GET: api/AnimeDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeData>> GetAnimeData(string id)
        {
            var animeData = await _context.AnimeData.FindAsync(id);

            if (animeData == null)
            {
                return NotFound();
            }

            return animeData;
        }

        // PUT: api/AnimeDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeData(string id, AnimeData animeData)
        {
            if (id != animeData.Name)
            {
                return BadRequest();
            }

            _context.Entry(animeData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeDataExists(id))
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

        // POST: api/AnimeDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimeData>> PostAnimeData(AnimeData animeData)
        {
            _context.AnimeData.Add(animeData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnimeDataExists(animeData.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnimeData", new { id = animeData.Name }, animeData);
        }

        // DELETE: api/AnimeDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeData(string id)
        {
            var animeData = await _context.AnimeData.FindAsync(id);
            if (animeData == null)
            {
                return NotFound();
            }

            _context.AnimeData.Remove(animeData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeDataExists(string id)
        {
            return _context.AnimeData.Any(e => e.Name == id);
        }
    }
}
