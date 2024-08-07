using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Entities;
using Shared.Interfaces;

namespace Shared.Repository
{
    /// <summary>
    /// Represents a repository for handling User entities.
    /// </summary>
    public class ChatRepository : AbstractRepository, IChatRepository
    {
        private readonly DbSet<Chat> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public ChatRepository(QuickChatDbContext context)
            : base(context)
        {
            this.dbSet = context.Set<Chat>();
        }

        /// <summary>
        /// Adds a new chat entity to the repository.
        /// </summary>
        /// <param name="entity">The chat entity to add.</param>
        public void Add(Chat entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a chat entity from the repository.
        /// </summary>
        /// <param name="entity">The chat entity to delete.</param>
        public void Delete(Chat entity)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a chat entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the chat entity to delete.</param>   
        public void DeleteById(int id)
        {
            var entity = this.GetById(id);
            this.Delete(entity);
        }

        /// <summary>
        /// Retrieves all chat entities from the repository.
        /// </summary>
        public IEnumerable<Chat> GetAll()
        {
            return this.dbSet.ToList();
        }

        /// <summary>
        /// Retrieves a paginated list of chat entities from the repository.
        /// </summary>
        /// <param name="pageNumber">The number of the page to retrieve.</param>
        /// <param name="rowCount">The number of user entities per page.</param>
        /// <returns>An enumerable collection of user entities for the specified page.</returns>
        public IEnumerable<Chat> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet.Skip(pageNumber * rowCount).Take(rowCount).ToList();
        }

        /// <summary>
        /// Retrieves a chat entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the chat entity to retrieve.</param>
        /// <returns>The chat entity with the specified identifier.</returns>
        public Chat GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        /// <summary>
        /// Updates an existing chat entity in the repository.
        /// </summary>
        /// <param name="entity">The chat entity to update.</param>
        public void Update(Chat entity)
        {
            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}