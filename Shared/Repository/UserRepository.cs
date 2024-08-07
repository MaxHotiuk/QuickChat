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
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private readonly DbSet<User> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public UserRepository(QuickChatDbContext context)
            : base(context)
        {
            this.dbSet = context.Set<User>();
        }

        /// <summary>
        /// Adds a new user entity to the repository.
        /// </summary>
        /// <param name="entity">The user entity to add.</param>
        public void Add(User entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a user entity from the repository.
        /// </summary>
        /// <param name="entity">The user entity to delete.</param>
        public void Delete(User entity)
        {
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a user entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the user entity to delete.</param>
        public void DeleteById(int id)
        {
            var entity = this.GetById(id);
            this.Delete(entity);
        }

        /// <summary>
        /// Retrieves all user entities from the repository.
        /// </summary>
        /// <returns>An enumerable collection of all user entities.</returns>
        public IEnumerable<User> GetAll()
        {
            return this.dbSet.ToList();
        }

        /// <summary>
        /// Retrieves a paginated list of user entities from the repository.
        /// </summary>
        /// <param name="pageNumber">The number of the page to retrieve.</param>
        /// <param name="rowCount">The number of user entities per page.</param>
        /// <returns>An enumerable collection of user entities for the specified page.</returns>
        public IEnumerable<User> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet.Skip(pageNumber * rowCount).Take(rowCount).ToList();
        }

        /// <summary>
        /// Retrieves a user entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the user entity to retrieve.</param>
        /// <returns>The user entity with the specified identifier.</returns>
        public User GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        /// <summary>
        /// Updates an existing user entity in the repository.
        /// </summary>
        /// <param name="entity">The user entity to update.</param>
        public void Update(User entity)
        {
            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}
