namespace QuickChat.Shared.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using QuickChat.Shared.Entities;

    /// <summary>
    /// Represents a repository interface for handling User entities.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Adds a new user entity to the repository.
        /// </summary>
        /// <param name="entity">The user entity to add.</param>
        new void Add(User entity);

        /// <summary>
        /// Deletes a user entity from the repository.
        /// </summary>
        /// <param name="entity">The user entity to delete.</param>
        new void Delete(User entity);

        /// <summary>
        /// Deletes a user entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the user entity to delete.</param>
        new void DeleteById(int id);

        /// <summary>
        /// Retrieves all user entities from the repository.
        /// </summary>
        /// <returns>An enumerable collection of all user entities.</returns>
        new IEnumerable<User> GetAll();

        /// <summary>
        /// Retrieves a paginated list of user entities from the repository.
        /// </summary>
        /// <param name="pageNumber">The number of the page to retrieve.</param>
        /// <param name="rowCount">The number of user entities per page.</param>
        /// <returns>An enumerable collection of user entities for the specified page.</returns>
        new IEnumerable<User> GetAll(int pageNumber, int rowCount);

        /// <summary>
        /// Retrieves a user entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the user entity to retrieve.</param>
        /// <returns>The user entity with the specified identifier.</returns>
        new User GetById(int id);

        /// <summary>
        /// Updates an existing user entity in the repository.
        /// </summary>
        /// <param name="entity">The user entity to update.</param>
        new void Update(User entity);
    }
}
