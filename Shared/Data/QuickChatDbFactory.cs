using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using QuickChat.Shared.Data.InitDataFactory;

namespace QuickChat.Shared.Data
{
    public class QuickChatDbFactory
    {
        private readonly IConfiguration _configuration;

        public QuickChatDbFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public QuickChatDbContext CreateContext()
        {
            var options = CreateOptions();
            return new QuickChatDbContext(options, new TestDataFactory());
        }

        private DbContextOptions<QuickChatDbContext> CreateOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuickChatDbContext>();
            optionsBuilder.UseSqlServer(CreateConnectionString());
            return optionsBuilder.Options;
        }

        private string CreateConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "quick-chat-db-server.database.windows.net",
                InitialCatalog = "QuickChatDB",
                UserID = "bezshumu",
                Password = "Bad#oy@@",
                Encrypt = true,
                TrustServerCertificate = false,
                ConnectTimeout = 30
            };
            return builder.ConnectionString;
        }
    }
}