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
using ApiAnime.Services;

namespace ApiAnime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDatasController : ControllerBase
    {
        private IUserService _userService;
        private readonly ApiAnimeContext _context;

        public UserDatasController(ApiAnimeContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> PutUser(string username, UserData userData)
        {
            if (username != userData.Username)
            {
                return BadRequest();
            }

            _context.Entry(userData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDataExists(username))
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



        [HttpPost]
        public async Task<ActionResult<AnimeData>> PostAnimeData(UserData userData)
        {
            _context.UserData.Add(userData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserDataExists(userData.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserData", new { Username = userData.Username }, userData);
        }



        // GET: api/AnimeDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserData>>> GetUserData()
        {
            return await _context.UserData.ToListAsync();
        }


        [HttpGet("{username}")]
        public ActionResult<List<UserData>> GetUserData_byName(string username)
        {
            var userData = _context.UserData.Where(u => u.Username.Equals(username)).ToList();

            if (userData == null)
            {
                return NotFound();
            }

            return userData;
        }

        private bool UserDataExists(string username)
        {
            return _context.UserData.Any(e => e.Username == username);
        }
    }
}
