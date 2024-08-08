using QuickChat.Shared.Data;
using QuickChat.Shared.Entities;
using System.Threading.Tasks;
using QuickChat.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
        public async Task<IActionResult> Register([FromBody] Dictionary<string, string> dataArray)
        {
            var user = new User
            {
                Name = dataArray["name"],
                LastName = dataArray["lastName"],
                Login = dataArray["login"],
                Password = dataArray["password"]
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Dictionary<string, string> dataArray)
        {
            // Login logic here
            return Ok();
        }
    }
}