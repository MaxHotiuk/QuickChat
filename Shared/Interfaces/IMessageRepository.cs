namespace QuickChat.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuickChat.Shared.Entities;

/// <summary>
/// Represents a repository interface for handling Message entities.
/// </summary>
public interface IMessageRepository : IRepository<Message>
{
    /// <summary>
    /// Adds a new Message entity to the repository.
    /// </summary>
    /// <param name="entity">The Message entity to add.</param>
    new void Add(Message entity);

    /// <summary>
    /// Deletes a Message entity from the repository.
    /// </summary>
    /// <param name="entity">The Message entity to delete.</param>
    new void Delete(Message entity);

    /// <summary>
    /// Deletes a Message entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the Message entity to delete.</param>
    new void DeleteById(int id);

    /// <summary>
    /// Retrieves all Message entities from the repository.
    /// </summary>
    /// <returns>An enumerable collection of all Message entities.</returns>
    new IEnumerable<Message> GetAll();

    /// <summary>
    /// Retrieves a paginated list of Message entities from the repository.
    /// </summary>
    /// <param name="pageNumber">The number of the page to retrieve.</param>
    /// <param name="rowCount">The number of Message entities per page.</param>
    /// <returns>An enumerable collection of Message entities for the specified page.</returns>
    new IEnumerable<Message> GetAll(int pageNumber, int rowCount);

    /// <summary>
    /// Retrieves a Message entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the Message entity to retrieve.</param>
    /// <returns>The Message entity with the specified identifier.</returns>
    new Message GetById(int id);

    /// <summary>
    /// Updates an existing Message entity in the repository.
    /// </summary>
    /// <param name="entity">The Message entity to update.</param>
    new void Update(Message entity);
}