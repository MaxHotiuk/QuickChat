using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickChat.Shared.Data;

namespace QuickChat.Shared.Repository
{
    /// <summary>
    /// Represents an abstract base class for repository implementations.
    /// </summary>
    public abstract class AbstractRepository
    {
        /// <summary>
        /// The database context used for interacting with the data QuickChat.
        /// </summary>
        protected readonly QuickChatDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        protected AbstractRepository(QuickChatDbContext context)
        {
            this.context = context;
        }
    }
}
