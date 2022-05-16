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

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}

        // GET: api/AnimeDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserData>>> GetUserData()
        {
            return await _context.UserData.ToListAsync();
        }
    }
}
