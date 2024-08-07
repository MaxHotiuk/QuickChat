namespace QuickChat.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickChat.Shared.Models;

/// <summary>
/// Interface for CRUD operations on AbstractModel entities.
/// </summary>
public interface ICrud
{
    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <returns>An enumerable collection of all entities.</returns>
    IEnumerable<AbstractModel> GetAll();

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>The entity with the specified ID.</returns>
    AbstractModel GetById(int id);

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="model">The entity to add.</param>
    void Add(AbstractModel model);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="model">The entity to update.</param>
    void Update(AbstractModel model);

    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="modelId">The ID of the entity to delete.</param>
    void Delete(int modelId);
}
