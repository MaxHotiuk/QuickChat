using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuickChat.Shared.Entities
{
    /// <summary>
    /// Represents a base entity with an integer identifier.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected BaseEntity(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class with default identifier (0).
        /// </summary>
        protected BaseEntity()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
    }
}