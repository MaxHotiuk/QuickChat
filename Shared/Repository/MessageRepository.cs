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
    /// Represents a repository for handling Message entities.
    /// </summary>
    public class MessageRepository : AbstractRepository, IMessageRepository
    {
        private readonly DbSet<Message> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public MessageRepository(QuickChatDbContext context)
            : base(context)
        {
            this.dbSet = context.Set<Message>();
        }

        /// <summary>
        /// Adds a new Message entity to the repository.
        /// </summary>
        /// <param name="entity">The Message entity to add.</param>
        public void Add(Message entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a Message entity from the repository.
        /// </summary>
        /// <param name="entity">The Message entity to delete.</param>
        public void Delete(Message entity)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a Message entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the Message entity to delete.</param>
        public void DeleteById(int id)
        {
            var entity = this.GetById(id);
            this.Delete(entity);
        }

        /// <summary>
        /// Retrieves all Message entities from the repository.
        /// </summary>
        /// <returns>An enumerable collection of all Message entities.</returns>
        public IEnumerable<Message> GetAll()
        {
            return this.dbSet.ToList();
        }

        /// <summary>
        /// Retrieves a paginated list of Message entities from the repository.
        /// </summary>
        /// <param name="pageNumber">The number of the page to retrieve.</param>
        /// <param name="rowCount">The number of Message entities per page.</param>
        /// <returns>An enumerable collection of Message entities for the specified page.</returns>
        public IEnumerable<Message> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet.Skip(pageNumber * rowCount).Take(rowCount).ToList();
        }

        /// <summary>
        /// Retrieves a Message entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the Message entity to retrieve.</param>
        /// <returns>The Message entity with the specified identifier.</returns>
        public Message GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        /// <summary>
        /// Updates an existing Message entity in the repository.
        /// </summary>
        /// <param name="entity">The Message entity to update.</param>
        public void Update(Message entity)
        {
            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}
