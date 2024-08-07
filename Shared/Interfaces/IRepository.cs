namespace Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Entities;

/// <summary>
/// Represents a generic repository interface for handling entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    /// <summary>
    /// Retrieves all entities from the repository.
    /// </summary>
    /// <returns>An enumerable collection of all entities.</returns>
    IEnumerable<TEntity> GetAll();

    /// <summary>
    /// Retrieves a paginated list of entities from the repository.
    /// </summary>
    /// <param name="pageNumber">The number of the page to retrieve.</param>
    /// <param name="rowCount">The number of entities per page.</param>
    /// <returns>An enumerable collection of entities for the specified page.</returns>
    IEnumerable<TEntity> GetAll(int pageNumber, int rowCount);

    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>The entity with the specified identifier.</returns>
    TEntity GetById(int id);

    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Add(TEntity entity);

    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Deletes an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to delete.</param>
    void DeleteById(int id);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(TEntity entity);
}
