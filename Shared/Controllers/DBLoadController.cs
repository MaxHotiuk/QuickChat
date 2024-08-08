using Microsoft.Extensions.Configuration;
using QuickChat.Shared.Data;

namespace QuickChat.Shared.Controllers
{
    public class DBLoadController
    {
        public QuickChatDbContext Context { get; }

        public DBLoadController(IConfiguration configuration)
        {
            var dbFactory = new QuickChatDbFactory(configuration);
            Context = dbFactory.CreateContext();
        }
    }
}