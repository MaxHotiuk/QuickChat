using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickChat.Shared.Data;
using QuickChat.Shared.Data.InitDataFactory;
using QuickChat.Shared.Entities;
using System.Threading.Tasks;
using QuickChat.Shared.Controllers;
using System.Linq;
using System;
using System.Collections.Generic;

namespace QuickChat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DBLoadController _dbLoadController;
        private readonly QuickChatDbContext _context;
        private static int userId;

        public AuthController(QuickChatDbContext context, DBLoadController dbLoadController)
        {
            _context = context;
            _dbLoadController = dbLoadController;
        }

        // POST api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Dictionary<string, string> dataArray)
        {
            var users = await _context.Users.ToArrayAsync();
            if (dataArray["name"] == null || dataArray["lastName"] == null || dataArray["login"] == null || dataArray["password"] == null)
            {
                return BadRequest("Invalid input.");
            }
            if (Array.Exists(users, u => u.Login == dataArray["login"]))
            {
                return BadRequest("User already exists.");
            }
            var user = new User(0, dataArray["name"], dataArray["lastName"], dataArray["login"], PasswordHelper.HashPassword(dataArray["password"]));
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            userId = user.Id;
            return Ok();
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Dictionary<string, string> dataArray)
        {
            var users = await _context.Users.ToArrayAsync();
            var user = Array.Find(users, u => u.Login == dataArray["login"]);
            if (user != null && dataArray["password"] != null && PasswordHelper.VerifyPassword(dataArray["password"], user.Password))
            {
                userId = user.Id;
            }
            else
            {
                return BadRequest("Invalid credentials.");
            }
        
            return Ok();
        }
    }
}