using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickChat.Shared.Data;
using QuickChat.Shared.Entities;
using System.Threading.Tasks;

namespace QuickChat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly QuickChatDbContext _context;

        public AuthController(QuickChatDbContext context)
        {
            _context = context;
        }

        // POST api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            if (ModelState.IsValid)
            {
                // Check if the user already exists
                var existingUser = await _context.Users
                    .SingleOrDefaultAsync(u => u.Login == user.Login);

                if (existingUser != null)
                {
                    return Conflict("User already exists.");
                }

                // Add and save the new user
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
            }

            return BadRequest(ModelState);
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("User login details are null.");
            }

            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .SingleOrDefaultAsync(u => u.Login == loginUser.Login && u.Password == loginUser.Password);

                if (user == null)
                {
                    return Unauthorized("Invalid credentials.");
                }

                return Ok("Login successful.");
            }

            return BadRequest(ModelState);
        }
    }
}
