namespace QuickChat.Shared.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using QuickChat.Shared.Data.InitDataFactory;
    using QuickChat.Shared.Entities;

    /// <summary>
    /// Represents the database context for the QuickChat application.
    /// </summary>
    public class QuickChatDbContext : DbContext
    {
        private readonly AbstractDataFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickChatDbContext"/> class.
        /// </summary>
        /// <param name="options">The DbContextOptions to be used for database configuration.</param>
        /// <param name="factory">The factory for providing initial data.</param>
        public QuickChatDbContext(DbContextOptions options, AbstractDataFactory factory)
            : base(options)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Gets or sets the DbSet for accessing the users in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for accessing the chats in the database.
        /// </summary>
        public DbSet<Chat> Chats { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for accessing the messages in the database.
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Configures the database schema and seeds initial data.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to construct the EF Core model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(this.factory.GetUserData());
            modelBuilder.Entity<Chat>().HasData(this.factory.GetChatData());
            modelBuilder.Entity<Message>().HasData(this.factory.GetMessageData());
        }
    }
}
