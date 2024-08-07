using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickChat.Shared.Entities;
using QuickChat.Shared.Data;
using System.Threading.Tasks;

namespace QuickChat.Server.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            var user = new User
            {
                Name = model.Name,
                LastName = model.LastName,
                Login = model.Login,
                Password = model.Password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User model)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
            if (user == null)
                return Unauthorized();

            return Ok();
        }
    }
}
