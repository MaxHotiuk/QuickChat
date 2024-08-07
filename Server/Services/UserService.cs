namespace Server.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using QuickChat.Server.Interfaces;
    using QuickChat.Server.Models;
    using QuickChat.Shared.Data;
    using QuickChat.Shared.Entities;
    using QuickChat.Shared.Interfaces;
    using QuickChat.Shared.Repository;

    /// <summary>
    /// Service class for managing users implementing the <see cref="ICrud"/> interface.
    /// </summary>
    public class UserService : ICrud
    {
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class with a database context.
        /// </summary>
        /// <param name="context">The database context used for repository operations.</param>
        public UserService(QuickChatDbContext context)
        {
            this.repository = new UserRepository(context);
        }

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="model">The user model to add.</param>
        public void Add(AbstractModel model)
        {
            var x = (UserModel)model;
            this.repository.Add(new User()
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Password = x.Password,
            });
        }

        /// <summary>
        /// Deletes a user by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the user to delete.</param>
        public void Delete(int modelId)
        {
            this.repository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all users from the repository.
        /// </summary>
        /// <returns>An enumerable collection of user models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            return this.repository.GetAll().Select(x => new UserModel(x.Id, x.Name, x.LastName, x.Login, x.Password));
        }

        /// <summary>
        /// Retrieves a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user model corresponding to the specified ID.</returns>
        public AbstractModel GetById(int id)
        {
            var res = this.repository.GetById(id);
            return new UserModel(res.Id, res.Name, res.LastName, res.Login, res.Password);
        }

        /// <summary>
        /// Updates an existing user in the repository.
        /// </summary>
        /// <param name="model">The updated user model.</param>
        public void Update(AbstractModel model)
        {
            var user = (UserModel)model;
            var existingUser = this.repository.GetById(user.Id);

            if (existingUser != null)
            {
                existingUser.Id = user.Id;
                existingUser.LastName = user.LastName;
                existingUser.Login = user.Login;
                existingUser.Name = user.Name;
                existingUser.Password = user.Password;
                this.repository.Update(existingUser);
            }
            else
            {
                throw new ArgumentException("User not found");
            }
        }
    }
}
