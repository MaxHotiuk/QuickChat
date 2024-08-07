using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared.Data.InitDataFactory;

namespace Shared.Data
{
    /// <summary>
    /// Factory for creating and configuring instances of QuickChatDbContext.
    /// </summary>
    public class QuickChatDbFactory
    {
        private readonly AbstractDataFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickChatDbFactory"/> class with the specified data factory.
        /// </summary>
        /// <param name="factory">The abstract data factory to use.</param>
        public QuickChatDbFactory(AbstractDataFactory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Creates a new instance of QuickChatDbContext with the configured options.
        /// </summary>
        /// <returns>The created QuickChatDbContext instance.</returns>
        public QuickChatDbContext CreateContext()
        {
            var context = new QuickChatDbContext(this.CreateOptions(), this.factory);

            // Ensure the database is created (Note: Avoid EnsureDeleted in production environments)
            context.Database.EnsureCreated();

            return context;
        }

        /// <summary>
        /// Creates DbContextOptions for configuring QuickChatDbContext with Azure SQL Database.
        /// </summary>
        /// <returns>The configured DbContextOptions instance.</returns>
        public DbContextOptions<QuickChatDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<QuickChatDbContext>()
                .UseSqlServer(CreateConnectionString())
                .Options;
        }

        /// <summary>
        /// Creates the Azure SQL Database connection string.
        /// </summary>
        /// <returns>The Azure SQL Database connection string.</returns>
        private static string CreateConnectionString()
        {
            // Replace these values with your Azure SQL Database credentials
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "quick-chat-db-server.database.windows.net", // Your Azure SQL Database server name
                InitialCatalog = "QuickChatDB", // Your database name
                UserID = "bezshumu", // Your database username
                Password = "Bad$oy@@", // Your database password
                TrustServerCertificate = true, // Set this to true if using a self-signed certificate
                Encrypt = true // Set this to true to encrypt the connection
            };

            return connectionStringBuilder.ConnectionString;
        }
    }
}
