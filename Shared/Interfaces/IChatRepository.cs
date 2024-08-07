namespace Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Entities;

/// <summary>
/// Represents a repository interface for handling Chat entities.
/// </summary>
public interface IChatRepository : IRepository<Chat>
{
    /// <summary>
    /// Adds a new chat entity to the repository.
    /// </summary>
    /// <param name="entity">The chat entity to add.</param>
    new void Add(Chat entity);

    /// <summary>
    /// Deletes a chat entity from the repository.
    /// </summary>
    /// <param name="entity">The chat entity to delete.</param>
    new void Delete(Chat entity);

    /// <summary>
    /// Deletes a chat entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the chat entity to delete.</param>
    new void DeleteById(int id);

    /// <summary>
    /// Retrieves all chat entities from the repository.
    /// </summary>
    /// <returns>An enumerable collection of all chat entities.</returns>
    new IEnumerable<Chat> GetAll();

    /// <summary>
    /// Retrieves a paginated list of chat entities from the repository.
    /// </summary>
    /// <param name="pageNumber">The number of the page to retrieve.</param>
    /// <param name="rowCount">The number of chat entities per page.</param>
    /// <returns>An enumerable collection of chat entities for the specified page.</returns>
    new IEnumerable<Chat> GetAll(int pageNumber, int rowCount);

    /// <summary>
    /// Retrieves a chat entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the chat entity to retrieve.</param>
    /// <returns>The chat entity with the specified identifier.</returns>
    new Chat GetById(int id);

    /// <summary>
    /// Updates an existing chat entity in the repository.
    /// </summary>
    /// <param name="entity">The chat entity to update.</param>
    new void Update(Chat entity);
}